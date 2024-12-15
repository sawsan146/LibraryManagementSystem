using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using Library_management_system.Entities;

namespace LibraryManagementSystem.Entities
{
    public class Library
    {
        private List<Books> Books = new List<Books>();
        private List<Books> BorrowedBooks = new List<Books>();

        string booksFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "books.json");
        string borrowedBooksFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "borrowedBooks.json");

        public Library()
        {
            LoadDataFromFile(booksFilePath, ref Books);
            LoadDataFromFile(borrowedBooksFilePath, ref BorrowedBooks);
        }

        // دالة مرنة لتحميل البيانات من الملف
        private void LoadDataFromFile(string filePath, ref List<Books> targetList)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    targetList = JsonSerializer.Deserialize<List<Books>>(data) ?? new List<Books>();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error loading data from {filePath}: " + ex.Message);
                Console.ResetColor();
                targetList = new List<Books>();
            }
        }

        // دالة مرنة لحفظ البيانات في الملف
        private void SaveDataToFile(string filePath, List<Books> data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error saving data to {filePath}: " + ex.Message);
                Console.ResetColor();
            }
        }

        public void AddBook(Books newBook)
        {
            Books.Add(newBook);
            SaveDataToFile(booksFilePath, Books);
            Console.WriteLine("\t\t\t\tBook added successfully.");
        }

        public void RemoveBook(string title)
        {
            // البحث عن الكتاب باستخدام العنوان
            var book = Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book != null)
            {
                // إذا كانت الكمية أكبر من صفر، نقوم بحذفه
                if (book.Quantity > 0)
                {
                    Books.Remove(book);
                    SaveDataToFile(booksFilePath, Books);
                    Console.WriteLine($"\t\t\t\t'{book.Title}' has been removed successfully.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\t\t\t\t'{book.Title}' has no quantity left to remove.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\t\t\t'{title}' was not found in the library.");
                Console.ResetColor();
            }
        }

        public void DisplayBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("\t\t\t\tNo books available.");
                return;
            }

            foreach (var book in Books)
            {
                if (book.Quantity > 0)  
                {
                    DisplayBook(book);
                }
            }
        }

        private void DisplayBook(Books book)
        {
            Console.WriteLine("\n\t\t------------------------------------");
            Console.WriteLine($"\t\t\tTitle       : {book.Title}");
            Console.WriteLine($"\t\t\tAuthor      : {book.Author}");
            Console.WriteLine($"\t\t\tDescription : {book.Description}");
            Console.WriteLine($"\t\t\tYear        : {book.Year}");
            Console.WriteLine($"\t\t\tQuantity    : {book.Quantity}\n");
        }

        public void Borrow(string title)
        {
            var book = SearchBookByTitle(title);

            if (book != null)
            {
                if (book.Quantity > 0)
                {
                    book.Quantity--;
                    if (book.Quantity == 0)
                    {
                        Books.Remove(book);
                        BorrowedBooks.Add(book);
                        SaveDataToFile(booksFilePath, Books);
                        SaveDataToFile(borrowedBooksFilePath, BorrowedBooks);
                        Console.WriteLine($"\t\t\t\t'{book.Title}' has been borrowed successfully.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\t\t\t\t'{book.Title}' is out of stock.");
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\t\t\t'{title}' was not found in the library.");
                Console.ResetColor();
            }
            
        }

        public void ReturnBook(string title)
        {
            var book = SearchBookByTitle(title);

            if (book != null)
            {
                book.Quantity++;  
                BorrowedBooks.Remove(book);
                SaveDataToFile(booksFilePath, Books);
                SaveDataToFile(borrowedBooksFilePath, BorrowedBooks);
                Console.WriteLine($"\t\t\t\t'{book.Title}' has been returned successfully.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\t\t\t'{title}' was not found in the borrowed books list.");
                Console.ResetColor();
            }
        }

        public void DisplayBorrowedBooks()
        {
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("\t\t\t\tNo books borrowed.");
                return;
            }

            foreach (var book in BorrowedBooks)
            {
                DisplayBook(book);
            }
        }

        public Books SearchBookByTitle(string title)
        {
            return Books.FirstOrDefault(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}
