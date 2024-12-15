using Library_management_system.Entities;
using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Screens
{
    public static class UserScreen
    {


        private static int SelectOptionscreen()
        {
            Console.Write("\t\t\tChoose To Do [1] Borrow  [2] Display Book [3] Exist : ");
            int option;

            while (!int.TryParse(Console.ReadLine(), out option) || (option > 3 || option < 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\t\tPlease Enter 1 ,2 or 3 : ");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return option;
        }


        public static void ShowUserScreen(Library library)
        {
            string User_Name = WelcomeHead.GetValidUserName();
            int User_Number= WelcomeHead.InputUserNumber();
            var CurrentUser = new LibraryUser(User_Name,User_Number);
            Console.Clear();


            while (true)
            {
                WelcomeHead.ShowWelcomeHead(User_Name);

              
                int option= SelectOptionscreen();
                switch (option)
                {
                    case 1:
                        Console.WriteLine("\n\t\tEnter Book Details");
                        Console.Write("\t\tBook Title: ");
                        string title = Console.ReadLine();
                        CurrentUser.BorrowBook(title, library);
                        break;
                    case 2:
                        CurrentUser.DisplayBooks(library);
                        break;
                    default:                      
                        LibFullScreens.Show();
                        break;
                }
            }
        }
    }
}

