using Library_management_system.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Screens
{
    public class WelcomeHead
    {
        public static void ShowWelcomeHead(string name)
        {
            Console.WriteLine("\n\n\t\t\t=============================================================");
            Console.WriteLine($"\t\t\t\tWelcome {name} to the library system");
            Console.WriteLine("\t\t\t=============================================================");
        }

        public static string GetValidUserName()
        {
            string name;
            while (true)
            {
                Console.Write("\n\t\t\t\tWelcome, Enter your name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\tName cannot be empty.");
                    Console.ResetColor();
                }
            }
        }

        public static int InputUserNumber()
        {
            Console.Write($"\n\t\t\t\tWelcome, Enter your Number : ");
            int number = int.Parse(Console.ReadLine());

            return number;
        }

        private static int GetValidUserNumber()
        {
            int User_Number;
            while (true)
            {
                Console.Write("\t\tUser Number: ");
                if (int.TryParse(Console.ReadLine(), out User_Number) && User_Number > 0)
                {
                    return User_Number;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tPlease enter a valid Number (positive integer).");
                    Console.ResetColor();
                }
            }
        }
    }
}
