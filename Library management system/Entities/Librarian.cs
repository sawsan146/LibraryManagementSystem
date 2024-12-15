using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Entities
{
    public class Librarian : Iuser
    {
        public int Employee_Id{ set;  get; }=0;
        public string Name { set; get; }
       

        public Librarian(string name) 
        {
            Name = name;
        }
        public void AddBook(Books NewBook, Library lib)
        {
            lib.AddBook(NewBook);
               }
        public void RemoveBook(string Title,Library lib)
        {
            lib.RemoveBook(Title);
        }

        public void DisplayBooks(Library lib)
        {
            lib.DisplayBooks();
        }

           public void DisplayBorrowedBooks(Library lib)
        {
            lib.DisplayBorrowedBooks();
        }


    }
}
