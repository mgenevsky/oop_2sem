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
        }

        // Book counter in logbook.
        public int Sum { get; private set; }

        //Login.
        public string Login { get; private set; }

        //User id.
        public int IdUser { get; private set; }

        // call events.
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

        // Method of taking a book.
        public virtual void Take(int idbook, Book book)
        {
            Sum += 1;
            OnTook(new AccountEventArgs($"The user with login \"{Login}\" took the book with id \"{idbook}\"", Login, idbook));
            logbooks.Add(book);
        }

        // Method of returning a book.
        public virtual Book Return(int idbook)
        {
            Book temp = logbooks.Find(x => x.IdBook == idbook);
            if (logbooks.Contains(new Book { IdBook = idbook }))
            {
                Sum -= 1;
                logbooks.Remove(new Book() { IdBook = idbook });
                OnReturned(new AccountEventArgs($"The user with login \"{Login}\" gave the book with id \"{idbook}\"", Login, idbook));
            }
            else
                OnReturned(new AccountEventArgs($"The user with login \"{Login}\" didn`t take the book with id \"{idbook}\"", Login, idbook));
            return temp;

        }

        // Method of opening an account.
        protected internal virtual void Open()
        {
            OnOpened(new AccountEventArgs($"A new user account has been created! User login: {Login} User id: {IdUser}", Login, 0));
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
                throw new Exception("This user hasn't taken any books yet, so his list is empty.");
        }

        // Method of closeing an account.
        protected internal virtual void Close()
        {
            OnClosed(new AccountEventArgs($"Account with login \"{Login}\" and Id \"{IdUser}\" is closed. This User left and didn`t give: {Sum} book(s)", Login, Sum));
        }
    }
}
