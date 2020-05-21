using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    public abstract class Account : IAccount
    {
        // The event that occurs when the book is returned.
        protected internal event AccountStateHandler Returned;
        // The event that occurs when the book is taken.
        protected internal event AccountStateHandler Took;
        // Event that occurs when opening an account.
        protected internal event AccountStateHandler Opened;
        // Event that occurs when looking book on account.
        protected internal event AccountStateHandler Look;
        // Event that occurs when closing an account.
        protected internal event AccountStateHandler Closed;
        // Event that occurs when login in account.
        protected internal event AccountStateHandler Logined;
        // Event that occurs when logout from account.
        protected internal event AccountStateHandler Logouted;

        // Static User Id.
        static int usercounter = 0;

        // Create a list of logbooks individual for each User.
        List<Book> logbooks = new List<Book>();

        // Ctor.
        public Account(string log)
        {
            Login = log;
            Sum = 0;
            IdUser = ++usercounter;
            AccType = 0;
        }

        // Book counter in logbook.
        public int Sum { get; private set; }

        // Account type.
        public int AccType { get; protected set; }

        // Login.
        public string Login { get; private set; }

        // User id.
        public int IdUser { get; private set; }

        // Method of getting User counter.
        public static int GetUserCounter() { return usercounter; }

        // Method of getting User account type.
        public string GetUserType()
        {
            switch (AccType)
            {
                case 1:
                    return "Admin";
                case 2:
                    return "Regular";
                default:
                    return "NONE";
            }

        }

        // Call events.
        private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if (e != null)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                handler?.Invoke(this, e);
                Console.ForegroundColor = color;
            }

        }

        // Call individual events. Each event has its own virtual method.
        protected virtual void OnOpened(AccountEventArgs e)
        {
            CallEvent(e, Opened);
        }
        protected virtual void OnReturned(AccountEventArgs e)
        {
            CallEvent(e, Returned);
        }
        protected virtual void OnTook(AccountEventArgs e)
        {
            CallEvent(e, Took);
        }
        protected virtual void OnLook(AccountEventArgs e)
        {
            CallEvent(e, Look);
        }
        protected virtual void OnClosed(AccountEventArgs e)
        {
            CallEvent(e, Closed);
        }
        protected virtual void OnLogin(AccountEventArgs e)
        {
            CallEvent(e, Logined);
        }
        protected virtual void OnLogout(AccountEventArgs e)
        {
            CallEvent(e, Logouted);
        }

        // Method of taking a book.
        public virtual void Take(int idbook, Book book)
        {
            Sum += 1;
            OnTook(new AccountEventArgs($"The account with login \"{Login}\" took the book with id \"{idbook}\"", Login, idbook));
            logbooks.Add(book);
            logbooks.Sort(delegate (Book x, Book y)
            {
                return x.IdBook.CompareTo(y.IdBook);
            });
        }

        // Method of returning a book.
        public virtual Book Return(int idbook)
        {
            Book temp = logbooks.Find(x => x.IdBook == idbook);
            if (logbooks.Contains(new Book { IdBook = idbook }))
            {
                Sum -= 1;
                logbooks.Remove(new Book() { IdBook = idbook });
                OnReturned(new AccountEventArgs($"The account with login \"{Login}\" return the book with id \"{idbook}\"", Login, idbook));
            }
            else
                throw new Exception("The account with login \"" + Login + "\" didn`t take the book with id \"" + idbook + "\"");
            return temp;
        }

        // Method of opening an account.
        protected internal virtual void Open()
        {
            OnOpened(new AccountEventArgs($"A new account has been created! User login: {Login} User id: {IdUser}", Login, 0));
        }

        // Logbooks viewing method.
        public virtual void LookAll()
        {
            if (logbooks.Count != 0)
            {
                OnLook(new AccountEventArgs($"List of all books taken users with User with login \"{Login}\":", Login, 0));
                foreach (Book aBook in logbooks)
                    Console.WriteLine(aBook);
            }
            else
                OnLook(new AccountEventArgs($"Account with login \"{Login}\" hasn't taken any books yet, so list is empty.", Login, 0));
        }

        // Method of closeing an account.
        protected internal virtual void Close()
        {
            OnClosed(new AccountEventArgs($"Account with login \"{Login}\" and Id \"{IdUser}\" is closed.", Login, 0));
        }

        // Method of login in account.
        protected internal virtual void LoginIn()
        {
            OnLogin(new AccountEventArgs($"You are logged in account with login \"{Login}\" ", Login, 0));
        }

        // Method of logoin out from account.
        protected internal virtual void LoginOut()
        {
            OnLogout(new AccountEventArgs($"You are logged out from account with login \"{Login}\" ", Login, 0));
        }
    }
}
