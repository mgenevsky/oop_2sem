using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AtheneumLibrary
{
    public enum AccountType
    {
        Admin,
        Simple 
    }
    public class Atheneum<T> where T : Account
    {
        List<Book> books = new List<Book>();
        static int bookscounter = 0;
        T[] accounts;
        public string Name { get; private set; }

        public Atheneum(string name)
        {
            Name = name;
        }
        // метод создания счета
        public void Open(AccountType accountType, string login,
            AccountStateHandler tookBookHandler, AccountStateHandler returnBookHandler,
            AccountStateHandler closeAccountHandler, AccountStateHandler openAccountHandler)
        {
            T newAccount = null;

            switch (accountType)
            {
                case AccountType.Admin:
                    newAccount = new AdminAccount(login) as T;
                    break;
                case AccountType.Simple:
                    newAccount = new UserAccount(login) as T;
                    break;
            }

            if (newAccount == null)
                throw new Exception("Ошибка создания аккаунта");
            // добавляем новый счет в массив счетов      
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
            // установка обработчиков событий счета
            newAccount.Took += tookBookHandler;
            newAccount.Returned += returnBookHandler;
            newAccount.Closed += closeAccountHandler;
            newAccount.Opened += openAccountHandler;

            newAccount.Open();
        }
        //добавление средств на счет
        public void Take(int idbook, int id)
        {
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Аккаунт не найдет");
            account.Take(idbook);
        }
        // вывод средств
        public void Return(int idbook, int id)
        {
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Аккаунт не найдет");
            account.Return(idbook);
        }
        // закрытие счета
        public void Close(int id)
        {
            int index;
            T account = FindAccount(id, out index);
            if (account == null)
                throw new Exception("Аккаунт не найдет");

            account.Close();

            if (accounts.Length <= 1)
                accounts = null;
            else
            {
                // уменьшаем массив счетов, удаляя из него закрытый счет
                T[] tempAccounts = new T[accounts.Length - 1];
                for (int i = 0, j = 0; i < accounts.Length; i++)
                {
                    if (i != index)
                        tempAccounts[j++] = accounts[i];
                }
                accounts = tempAccounts;
            }
        }

        // поиск счета по id
        public T FindAccount(int id)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].IdUser == id)
                    return accounts[i];
            }
            return null;
        }
        // перегруженная версия поиска аккаунта
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
        public void AddBook(string Name, string Author, string Genre)
        {
            books.Add(new Book() { IdBook = ++bookscounter, name = Name, author = Author, genre = Genre });
        }
        public void LookAll()
        {
            foreach (Book aBook in books)
            {
                Console.WriteLine(aBook);
            }
        }
        public void Search(int flag, string key)
        {
            switch (flag)
            {
                case 1:
                    Console.WriteLine($"\nПоиск: Книжки где содержиться \"{key}\" в названии:");
                    List<Book> resultName = books.FindAll(FindName);
                    if (resultName.Count != 0)
                    {
                        foreach (Book b in resultName)
                            Console.WriteLine(b);
                    }
                    else
                        Console.WriteLine("\nТакие книжки не найдены!");
                    bool FindName(Book book)
                    {
                        if (book.name == key)
                            return true;
                        else
                            return false;
                    }
                    break;
                case 2:
                    Console.WriteLine($"\nПоиск: Книжки где в авторах есть имя \"{key}\" :");
                    List<Book> resultAuthor = books.FindAll(FindAuthor);
                    if (resultAuthor.Count != 0)
                    {
                        foreach (Book b in resultAuthor)
                            Console.WriteLine(b);
                    }
                    else
                        Console.WriteLine("\nТакие книжки не найдены!");
                    bool FindAuthor(Book book)
                    {
                        if (book.author == key)
                            return true;
                        else
                            return false;
                    }
                    break;
                case 3:
                    Console.WriteLine($"\nПоиск: Книжки с жанром \"{key}\" :");
                    List<Book> resultGenre = books.FindAll(FindGenre);
                    if (resultGenre.Count != 0)
                    {
                        foreach (Book b in resultGenre)
                            Console.WriteLine(b);
                    }
                    else
                        Console.WriteLine("\nТакие книжки не найдены!");
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
        public void Remove(int idbook)
        {
            books.Remove(new Book() { IdBook = idbook });
        }
        public void Sort()
        {
            books.Sort(delegate (Book x, Book y)
            {
                return x.IdBook.CompareTo(y.IdBook);
            });
        }

        public void AddBook(int idbook)
        {

        }
    }
}
