using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AtheneumLibrary
{
    // Account Type.
    public enum AccountType
    {
        Admin,
        Regular
    }

    public class Atheneum<T> where T : Account
    {
        // Create a list of books.
        List<Book> books = new List<Book>();
        static int bookscounter = 0;
        T[] accounts;
        public string Name { get; private set; }

        // Ctor.
        public Atheneum(string name) {   Name = name; }

        // Account creation method.
        public void Open(AccountType accountType, string login,
            AccountStateHandler tookBookHandler, AccountStateHandler returnBookHandler,
            AccountStateHandler closeAccountHandler, AccountStateHandler openAccountHandler, 
            AccountStateHandler loginAccountHandler, AccountStateHandler logoutAccountHandler, AccountStateHandler lookAccountHandler)
        {
            T newAccount = null;

            switch (accountType)
            {
                case AccountType.Admin:
                    newAccount = new AdminAccount(login) as T;
                    break;
                case AccountType.Regular:
                    newAccount = new RegularAccount(login) as T;
                    break;
            }

            if (newAccount == null)
                throw new Exception("Error creating account");
            // add a new account to the account array   
            if (accounts == null)
                accounts = new T[] { newAccount };
            else
            {
                T[] tempAccounts = new T[accounts.Length + 1];
                for (int i = 0; i < accounts.Length; i++)
                    tempAccounts[i] = accounts[i];
                tempAccounts[tempAccounts.Length - 1] = newAccount;
                accounts = tempAccounts;
            }
            // install account event handlers
            newAccount.Took += tookBookHandler;
            newAccount.Returned += returnBookHandler;
            newAccount.Closed += closeAccountHandler;
            newAccount.Opened += openAccountHandler;
            newAccount.Logined += loginAccountHandler;
            newAccount.Look += lookAccountHandler;
            newAccount.Logouted += logoutAccountHandler;
            newAccount.Open();
        }

        // Method of taking a book to an account.
        public void Take(int id)
        {
            Console.WriteLine("Enter the Id of the book you want to take:");
            int idbook = Convert.ToInt32(Console.ReadLine());
            if (books.Exists(x => x.IdBook == idbook))
            {
                Book temp = books.Find(x => x.IdBook == idbook);
                FindAccount(id).Take(idbook, temp);
                Remove(idbook);
            }
            else
                throw new Exception("Book with such Id isn`t in our library");
        }

        // Method return book from account.
        public void Return(int id)
        {
            Console.WriteLine("Enter the Id of the book you want to return:");
            int idbook = Convert.ToInt32(Console.ReadLine());
            Book temp = new Book();
            temp = FindAccount(id).Return(idbook);
            if (temp != null)
                books.Add(temp);
            books.Sort(delegate (Book x, Book y)
            {
                return x.IdBook.CompareTo(y.IdBook);
            });
        }

        // Method for viewing books taken by a specific user.
        private void AccountLook(int id)
        {
            if (FindAccount(id) == null)
                throw new Exception("Аccount will not find");
            FindAccount(id).LookAll();
        }

        // Account deletion method.
        private void Close(int id)
        {
            int index;

            if (FindAccount(id, out index) == null)
                throw new Exception("Аccount will not find");
            if (FindAccount(id, out index).Sum == 0)
            {
                FindAccount(id, out index).Close();
                if (accounts.Length <= 1)
                    accounts = null;
                else
                {
                    T[] tempAccounts = new T[accounts.Length - 1];
                    for (int i = 0, j = 0; i < accounts.Length; i++)
                    {
                        if (i != index)
                            tempAccounts[j++] = accounts[i];
                    }
                    accounts = tempAccounts;
                }
            }
            else
                throw new Exception("Account with login \""+ FindAccount(id, out index).Login + "\" and Id \""+ FindAccount(id, out index).IdUser + "\" cann`t leave until he gives all the books back!.");
        }

        // Id account search method.
        private T FindAccount(int id)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].IdUser == id)
                    return accounts[i];
            }
            return null;
        }

        // Overloaded version of account search.
        private T FindAccount(int id, out int index)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].IdUser == id)
                {
                    index = i;
                    return accounts[i];
                }
            }
            index = -1;
            return null;
        }

        // Method to Add book to a list in library.
        public void AddBook(string Name, string Author, string Genre)
        {
            if (Name == "" || Author == "" || Genre == "")
                throw new Exception("You cannot add a book where one of the parameters is empty!");
            books.Add(new Book() { IdBook = ++bookscounter, name = Name, author = Author, genre = Genre });
            books.Sort(delegate (Book x, Book y)
            {
                return x.IdBook.CompareTo(y.IdBook);
            });
        }

        // Method for viewing all books in library.
        public void LookAllBooks()
        {
            if (books.Count != 0)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("List of all books in library \"" + Name + "\":");
                Console.ForegroundColor = color;
                foreach (Book aBook in books)
                    Console.WriteLine(aBook);
            }
            else
                throw new Exception("There are no books in library \"" + Name + "\"");
        }

        // Method for viewing all accounts in library.
        private void LookAllAccounts()
        {
            if (Account.GetUserCounter() != 0)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("List of all accounts in library \"" + Name + "\":");
                Console.ForegroundColor = color;
                for (int i = 0; i < Account.GetUserCounter(); i++)
                    Console.WriteLine("User Id: " + accounts[i].IdUser + "\tLogin: " + accounts[i].Login + "\tAccount type: " + accounts[i].GetUserType() + "\tNumber of books taken: " + accounts[i].Sum);
            }
            else
                throw new Exception("There are no accounts in library \"" + Name + "\"");
        }

        // Book search method by parameter.
        public void Search()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Indicate the type of book search:");
            Console.WriteLine("1. Search by name 2. Search by author 3. Search by genre");
            int flag = Convert.ToInt32(Console.ReadLine());
            if ((flag != 1) && (flag != 2) && (flag != 3))
                throw new Exception("This item does not exist, try again");
            Console.WriteLine("Enter your search keyword:");
            Console.ForegroundColor = color;
            string key = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            switch (flag)
            {
                case 1: // book search by name
                    Console.WriteLine("Searching...");
                    Console.ForegroundColor = color;
                    List<Book> resultName = books.FindAll(FindName);
                    if (resultName.Count != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Books where \"{key}\" is contained in the title:");
                        Console.ForegroundColor = color;
                        foreach (Book b in resultName)
                            Console.WriteLine(b);
                    }
                    else
                        throw new Exception("No such books were found!");
                    bool FindName(Book book)
                    {
                        if (book.name == key)
                            return true;
                        else
                            return false;
                    }
                    break;
                case 2: // book search by author
                    Console.WriteLine("Searching...");
                    Console.ForegroundColor = color;
                    List<Book> resultAuthor = books.FindAll(FindAuthor);
                    if (resultAuthor.Count != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Books where the author has the name \"{key}\":");
                        Console.ForegroundColor = color;
                        foreach (Book b in resultAuthor)
                            Console.WriteLine(b);
                    }
                    else
                        throw new Exception("No such books were found!");
                    bool FindAuthor(Book book)
                    {
                        if (book.author == key)
                            return true;
                        else
                            return false;
                    }
                    break;
                case 3: // book search by genre
                    Console.WriteLine("Searching...");
                    Console.ForegroundColor = color;
                    List<Book> resultGenre = books.FindAll(FindGenre);
                    if (resultGenre.Count != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Books with the genre \"{key}\":");
                        Console.ForegroundColor = color;
                        foreach (Book b in resultGenre)
                            Console.WriteLine(b);
                    }
                    else
                        throw new Exception("No such books were found!");
                    bool FindGenre(Book book)
                    {

                        if (book.genre == key)
                            return true;
                        else
                            return false;
                    }
                    break;
            }
        }

        // Method to Remove book from a list.
        private void Remove(int idbook)
        {
            Book temp = books.Find(x => x.IdBook == idbook);
            if (books.Contains(new Book { IdBook = idbook }))
            {
                books.Remove(temp);
                books.Sort(delegate (Book x, Book y)
                {
                    return x.IdBook.CompareTo(y.IdBook);
                });
            }
            else
                throw new Exception("You cannot delete a book that is not in the library");

        }

        // Account login method.
        public void LoginAccount(int idUser)
        {
            Account account = FindAccount(idUser);
            if (account == null)
                throw new Exception("Аccount will not find");
            FindAccount(idUser).LoginIn();
            switch (account.AccType)
            {
                case 1:
                    AdminAccountMenu(idUser);
                    break;
                case 2:
                    RegularAccountMenu(idUser);
                    break;
            }
        }

        // Admin Account menu call method.
        private void AdminAccountMenu(int idUser)
        {
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n1. Take a book \t   2. Return a book \t   3. View account books   4. Book search\n5. Add a book      6. Remove a book \t   7. Delete account \t   8. Account List\n9. View a list of books in our library");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("10. Log out");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nEnter item number:");
                Console.ForegroundColor = color;
                try
                {
                    int flag = Convert.ToInt32(Console.ReadLine());
                    switch (flag)
                    {
                        case 1:
                            Take(idUser);
                            break;
                        case 2:
                            Return(idUser);
                            break;
                        case 3:
                            Console.WriteLine("Enter the account ID on which you want to see logbook:");
                            int id3 = Convert.ToInt32(Console.ReadLine());
                            AccountLook(id3);
                            break;
                        case 4:
                            Search();
                            break;
                        case 5:
                            Console.WriteLine("Enter the author name and the genre of the book you want to add through enter:");
                            Console.WriteLine("Name: ");
                            string Name = Console.ReadLine();
                            Console.WriteLine("Author: ");
                            string Author = Console.ReadLine();
                            Console.WriteLine("Genre: ");
                            string Genre = Console.ReadLine();
                            AddBook(Name, Author, Genre);
                            break;
                        case 6:
                            Console.WriteLine("Enter the book ID you want to delete:");
                            int id5 = Convert.ToInt32(Console.ReadLine());
                            Remove(id5);
                            break;
                        case 7:
                            Console.WriteLine("Enter the id of the account to be closed:");
                            int id6 = Convert.ToInt32(Console.ReadLine());
                            Close(id6);
                            if (idUser == id6)
                            {
                                alive = false;
                                throw new Exception("You deleted your own account so you were thrown out of the menu");
                            }
                            break;
                        case 8:
                            LookAllAccounts();
                            break;
                        case 9:
                            LookAllBooks();
                            break;
                        case 10:
                            FindAccount(idUser).LoginOut();
                            alive = false;
                            continue;
                        default:
                            throw new Exception("This item does not exist, try again");
                    }

                }
                catch (Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }

            }

        }

        // Regular Account menu call method.
        private void RegularAccountMenu(int idUser)
        {
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n1. Take a book \t   2. Return a book \t   3. View my account books\n4. Book search \t   5. Delete my account    6. View a list of books in our library");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("7. Log out");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nEnter item number:");
                Console.ForegroundColor = color;
                try
                {
                    int flag = Convert.ToInt32(Console.ReadLine());
                    switch (flag)
                    {
                        case 1:
                            Take(idUser);
                            break;
                        case 2:
                            Return(idUser);
                            break;
                        case 3:
                            FindAccount(idUser).LookAll();
                            break;
                        case 4:
                            Search();
                            break;
                        case 5:
                            Close(idUser);
                            alive = false;
                            throw new Exception("You deleted your own account so you were thrown out of the menu");
                        case 6:
                            LookAllBooks();
                            break;
                        case 7:
                            FindAccount(idUser).LoginOut();
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
    }
}