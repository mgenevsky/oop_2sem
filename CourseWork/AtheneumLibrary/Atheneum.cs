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

        //Ctor.
        public Atheneum(string name)
        {
            Name = name;
        }

        // Account creation method.
        public void Open(AccountType accountType, string login,
            AccountStateHandler tookBookHandler, AccountStateHandler returnBookHandler,
            AccountStateHandler closeAccountHandler, AccountStateHandler openAccountHandler, AccountStateHandler lookAccountHandler)
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
            newAccount.Look += lookAccountHandler;

            newAccount.Open();
        }

        // Method of taking a book to an account.
        public void Take(int idbook, int id)
        {
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Аccount will not find");
            if (books.Exists(x => x.IdBook == idbook))
            {
                Book temp = books.Find(x => x.IdBook == idbook);
                account.Take(idbook, temp);
                Remove(idbook);
                Sort();
            }
            else
                throw new Exception("Book with such Id isn`t in our library");
        }

        // Method return book from account.
        public void Return(int idbook, int id)
        {
            Book temp = new Book();
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Аccount will not find");
            temp = account.Return(idbook);
            if (temp != null)
                books.Add(temp);
            Sort();
        }

        // Method for viewing books taken by a specific user.
        public void UserLook(int id)
        {
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Аccount will not find");
            account.LookAll();
        }

        // Account deletion method.
        public void Close(int id)
        {
            int index;
            T account = FindAccount(id, out index);
            if (account == null)
                throw new Exception("Аccount will not find");

            account.Close();

            if (accounts.Length <= 1)
                accounts = null;
            else
            {
                // reduce the array of accounts, removing the closed account from it
                T[] tempAccounts = new T[accounts.Length - 1];
                for (int i = 0, j = 0; i < accounts.Length; i++)
                {
                    if (i != index)
                        tempAccounts[j++] = accounts[i];
                }
                accounts = tempAccounts;
            }
        }

        // Id account search method.
        public T FindAccount(int id)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].IdUser == id)
                    return accounts[i];
            }
            return null;
        }

        // Overloaded version of account search.
        public T FindAccount(int id, out int index)
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
            books.Add(new Book() { IdBook = ++bookscounter, name = Name, author = Author, genre = Genre });
        }

        // Method for viewing all books in library.
        public void LookAll()
        {
            if (books.Count != 0)
            {
                Console.WriteLine("List of all books in our library:");
                foreach (Book aBook in books)
                    Console.WriteLine(aBook);
            }
            else
                throw new Exception("There are no books in library");
        }

        // Book search method by parameter.
        public void Search(int flag, string key)
        {
            switch (flag)
            {
                case 1: // book search by name
                    Console.WriteLine("Searching...");
                    List<Book> resultName = books.FindAll(FindName);
                    if (resultName.Count != 0)
                    {
                        Console.WriteLine($"Books where \"{key}\" is contained in the title:");
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
                    List<Book> resultAuthor = books.FindAll(FindAuthor);
                    if (resultAuthor.Count != 0)
                    {
                        Console.WriteLine($"Books where the author has the name \"{key}\":");
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
                    List<Book> resultGenre = books.FindAll(FindGenre);
                    if (resultGenre.Count != 0)
                    {
                        Console.WriteLine($"Books with the genre \"{key}\":");
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
        public void Remove(int idbook)
        {
            books.Remove(new Book() { IdBook = idbook });
        }

        //Method to Sort books in a list.
        public void Sort()
        {
            books.Sort(delegate (Book x, Book y)
            {
                return x.IdBook.CompareTo(y.IdBook);
            });
        }
    }
}
