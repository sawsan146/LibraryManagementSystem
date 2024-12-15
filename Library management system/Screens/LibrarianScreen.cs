using Library_management_system.Entities;
using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Screens
{



    public static class LibrarianScreen
    {
        private static int GetValidQuantity()
        {
            int quantity;
            while (true)
            {
                Console.Write("\t\tquantity: ");
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                {
                    return quantity;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tPlease enter a valid positive quantity.");
                    Console.ResetColor();
                }
            }

        }
        private static int GetValidYear()
        {
            int year;
            while (true)
            {
                Console.Write("\t\tBook Year: ");
                if (int.TryParse(Console.ReadLine(), out year) && year > 0 && year <= DateTime.Now.Year)
                {
                    return year;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tPlease enter a valid year (positive integer and not in the future).");
                    Console.ResetColor();
                }
            }
        }
        private static string GetValidStringInput(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write($"\t\t{prompt}: ");
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tInput cannot be empty.");
                    Console.ResetColor();
                }
            }
        }

        private static Books AddBookScreen()
        {
            Console.WriteLine("\n\t\tEnter Book Details");

            string title = GetValidStringInput("Book Title");
            string author = GetValidStringInput("Book Author");
            string description = GetValidStringInput("Book Description");
            int year = GetValidYear();
            int quantity = GetValidQuantity();

            Books NewBook = new Books(title, author, description, year, quantity);
            return NewBook;
        }
        private static string RemoveBookScreen()
        {
            Console.WriteLine("\n\t\tEnter Book Details");

            string title = GetValidStringInput("Book Title");
            return title;
        }

       

        private static int SelectOptionscreen()
        {

            Console.Write("\t\tChoose To Do [1] Add Book  [2] Remove Book [3] Display Books \n\t\t[4] Display Borrowed Books [5] Exist : ");
            int option2;
            while (!int.TryParse(Console.ReadLine(), out option2) || (option2 > 5 || option2 < 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\t\tPlease Enter [1:5] : ");
                Console.ForegroundColor = ConsoleColor.White;

            }
            return option2;
        }

        public static void ShowLibrarianScreen(Library library)
        {
            string Librarian_Name = WelcomeHead.GetValidUserName();
            var CurrentLibrarian = new Librarian(Librarian_Name);
            Console.Clear();


            while (true)
            {
                WelcomeHead.ShowWelcomeHead(Librarian_Name);

                int option=SelectOptionscreen();

                switch (option)
                {
                    case 1:
                        var NewBook = AddBookScreen();
                        CurrentLibrarian.AddBook(NewBook, library);

                        break;
                    case 2:
                        string title = RemoveBookScreen();

                        CurrentLibrarian.RemoveBook(title, library);
                        break;

                    case 3:
                        CurrentLibrarian.DisplayBooks(library);
                        break;
                    case 4:
                        CurrentLibrarian.DisplayBorrowedBooks(library);
                        break;

                    default:
                        LibFullScreens.Show();
                        break;
                }


            }
        }
    }
}
