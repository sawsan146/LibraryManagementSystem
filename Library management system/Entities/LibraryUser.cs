using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Entities
{
    public class LibraryUser : Iuser
    {
        public LibraryCard Card { get; set; } = new LibraryCard();
        public string Name { get ; set ; }  


        public LibraryUser(string name,int number)
        {
            Name = name;
            Card.Number = number;
            Card.UserName= name;
        }
     
      

        public void BorrowBook(string title, Library lib)
        {
            lib.Borrow(title);
        }

        public void DisplayBooks(Library lib)
        {
            lib.DisplayBooks();
        }
    }
}
