using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class Displays
    {
        public void StartPage()
        {
            Console.WriteLine();
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Register new user");
        }
        public void mainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("     Main Menu");
            Console.WriteLine("1. Add friend");
            Console.WriteLine("2. View friends");
            Console.WriteLine("3. Log out");
            Console.WriteLine();
        }
        public void LoggingIn(string userName)
        {
            Console.WriteLine();
            Console.WriteLine($"Logging in {userName}");
            Thread.Sleep(1000);
        }
        public void LoggingOut(User loggedInUser)
        {
            Console.WriteLine();
            Console.WriteLine($"Logging out {loggedInUser.Name}");
            Thread.Sleep(500);
        }

        public void FriendDisplay()
        {
            Console.WriteLine();
            Console.WriteLine("    Commands");
            Console.WriteLine("1. View friend details");
            Console.WriteLine("2. Remove friend");
            Console.WriteLine("3. Back to menu");
        }
    }
}
