using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Screens
{
    public static class LibFullScreens
    {

        private static int SelectOptionscreen()
        {

            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || (option > 3 || option < 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\t\tPlease Enter 1 or 2: ");
                Console.ForegroundColor = ConsoleColor.White;

            }
            return option;
        }
        public static void Show()
        {
            Console.Clear();
            while (true)
            {
                MainScreen.ShowMainScreen();
                Library library = new Library();

                int option = SelectOptionscreen();
                Console.Clear();

                if (option == 1){

                    LibrarianScreen.ShowLibrarianScreen(library);
                }
                else if (option == 2){

                    UserScreen.ShowUserScreen(library);
                }
                else{
                    Environment.Exit(0);
                }
            }
        }
    }
}

