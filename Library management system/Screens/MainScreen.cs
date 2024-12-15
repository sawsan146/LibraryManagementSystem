using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Screens
{
    public static class MainScreen
    {
        public static void ShowMainScreen()
        {
            Console.WriteLine("\t\t\t=============================================================");
            Console.WriteLine("\t\t\t\t\tWelcome to the library system");
            Console.WriteLine("\t\t\t=============================================================");
            Console.Write("\n\n\t\t\tAre You [1] Librarian or [2] Regular user [3] Exit [1:3]: ");

        }
    }
}
