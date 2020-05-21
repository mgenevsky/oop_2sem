using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AtheneumLibrary;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Atheneums.
            Atheneum<Account> library = new Atheneum<Account>("KPI Library");

            // Add books to a specific library.
            library.AddBook("Arm", "lolowtg", "xd");
            library.AddBook("Points", "NS", "idk");
            library.AddBook("Sit", "Stray", "xd");
            library.AddBook("Arm", "Silvername", "lmao");
            library.AddBook("Arm", "Aloha", "lol");
            library.AddBook("cassette", "lolowtg", "xd");
            library.AddBook("Sit", "Stray", "lmao");
            library.AddBook("Sit", "Stray", "lmao");

            bool alive = true;
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to the KPI Library");
            while (alive)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n1. Create an account \t   2. Login account\n3. Book search \t\t   4. View a list of books in our library");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("5. Exit the program");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nEnter item number:");
                Console.ForegroundColor = color;
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            OpenAccount(library);
                            break;
                        case 2:
                            LoginAccount(library);
                            break;
                        case 3:
                            Search(library);
                            break;
                        case 4:
                            LookAllBooks(library);
                            break;
                        case 5:
                            alive = false;
                            continue;
                        default:
                            throw new Exception("This item does not exist, try again");
                    }
                }
                catch (Exception ex)
                {
                    // Display an error message with red color.
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }

        // Method of opening an account in specific library.
        private static void OpenAccount(Atheneum<Account> library)
        {
            Console.WriteLine("Enter login:");
            string login = Console.ReadLine();
            if (login=="")
                throw new Exception("Login cann`t be empty");
            Console.WriteLine("Select an account type:");
            Console.WriteLine("1. Admin 2. Regular");
            AccountType accountType;
            int type = Convert.ToInt32(Console.ReadLine());
            switch (type)
            {
                case 1:
                    accountType = AccountType.Admin;
                    break;
                case 2:
                    accountType = AccountType.Regular;
                    break;
                default:
                    throw new Exception("This type of account does not exist");
            }

            library.Open(accountType,
                login,
                TookBookHandler,  // take book handler
                ReturnBookHandler, // book return handler
                CloseAccountHandler, // account closing handler
                OpenAccountHandler, // account opening handler
                LoginAccountHandler, // account login handler.
                LogoutAccountHandler, // account logout handler.
                LookAccountHandler); // looking for all books at account handler
        }

        // Book search method by parameter in specific library.
        private static void Search(Atheneum<Account> library)
        {
            library.Search();
        }

        // Account login method.
        private static void LoginAccount(Atheneum<Account> library)
        {
            Console.WriteLine("Enter the account ID you want to login to:");
            int idUser = Convert.ToInt32(Console.ReadLine());
            library.LoginAccount(idUser);
        }

        // Method for viewing all books in specific library.
        private static void LookAllBooks(Atheneum<Account> library)
        {
            library.LookAllBooks();
        }

        // account event handlers.
        // account creation handler.
        private static void OpenAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // account login handler.
        private static void LoginAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // account logout handler.
        private static void LogoutAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // take book handler.
        private static void TookBookHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // book return handler.
        private static void ReturnBookHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // account deletion handler.
        private static void CloseAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // looking for all account books handler.
        private static void LookAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
