using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Entities
{
    public class Books
    {
        public Books() { }
        public Books(string title, string des, string author, int year, int quantity)
        {
            Title = title;
            Description = des;
            Author = author;
            Year = year;
            Quantity = quantity;
        }
        public string Title { set; get; }
        public string Description { set; get; }
        public string Author { set; get; }
        public int Year { set; get; }

        public int Quantity { set; get; }

        public override bool Equals(object obj)
        {
            if (obj is Books other)
            {
                return Title == other.Title && Author == other.Author && Year == other.Year;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author, Year);
        }
    }
}


