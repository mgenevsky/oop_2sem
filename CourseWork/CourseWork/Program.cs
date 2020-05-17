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

            // Add books to a specific library
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
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("1. Create an account \t   2. Take a book \t    3. Return a book");
                Console.WriteLine("4. Book search \t\t   5. View a list of books in our library");
                Console.WriteLine("6. View user books \t   7. Delete account \t    8. Exit the program");
                Console.WriteLine("Enter item number:");
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
                            Take(library);
                            break;
                        case 3:
                            Return(library);
                            break;
                        case 4:
                            Search(library);
                            break;
                        case 5:
                            LookAll(library);
                            break;
                        case 6:
                            UserLook(library);
                            break;
                        case 7:
                            CloseAccount(library);
                            break;
                        case 8:
                            alive = false;
                            continue;
                        default:
                            throw new Exception("This item does not exist, try again");
                    }
                }
                catch (Exception ex)
                {
                    // display an error message with red color
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

            Console.WriteLine("Select an account type:");
            Console.WriteLine("1. Admin 2. Normal");
            AccountType accountType;
            int type = Convert.ToInt32(Console.ReadLine());
            if (type == 2)
                accountType = AccountType.Regular;
            else
                accountType = AccountType.Admin;

            library.Open(accountType,
                login,
                TookBookHandler,  // take book handler
                ReturnBookHandler, // book return handler
                CloseAccountHandler, // account closing handler
                OpenAccountHandler, // account opening handler
                LookAccountHandler); // looking for all books at account handler
        }

        // Method of returning a book in specific library.
        private static void Return(Atheneum<Account> library)
        {
            Console.WriteLine("Enter the Id of the Account that wanted to return the book:");
            int idUser = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Id of the book you want to return:");
            int idbook = Convert.ToInt32(Console.ReadLine());
            library.Return(idbook, idUser);
        }

        // Method for viewing books taken by a specific user in specific library.
        private static void UserLook(Atheneum<Account> library)
        {
            Console.WriteLine("Enter the Id of the Account where you want to see the list of books:");
            int idUser = Convert.ToInt32(Console.ReadLine());
            library.UserLook(idUser);
        }

        // Method of taking a book in specific library.
        private static void Take(Atheneum<Account> library)
        {
            Console.WriteLine("Enter the Id of the Account that wanted to take the book:");
            int idUser = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Id of the book you want to take:");
            int idbook = Convert.ToInt32(Console.ReadLine());
            library.Take(idbook, idUser);
        }

        // Method of closeing an account in specific library.
        private static void CloseAccount(Atheneum<Account> library)
        {
            Console.WriteLine("Enter the id of the account to be closed:");
            int id = Convert.ToInt32(Console.ReadLine());
            library.Close(id);
        }

        // Book search method by parameter in specific library.
        private static void Search(Atheneum<Account> library)
        {
            Console.WriteLine("Indicate the type of book search:");
            Console.WriteLine("1. Search by name 2. Search by author 3. Search by genre");
            int flag = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your search keyword:");
            string key = Console.ReadLine();
            library.Search(flag, key);
        }

        // Method for viewing all books in specific library.
        private static void LookAll(Atheneum<Account> library)
        {
            library.LookAll();
        }

        // account event handlers.
        // account creation handler.
        private static void OpenAccountHandler(object sender, AccountEventArgs e)
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

        // looking for all acoount books handler.
        private static void LookAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
