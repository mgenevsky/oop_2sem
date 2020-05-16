using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    public interface IAccount
    {
        // Take a book from the library.
        void Take(int idBook, Book book);
        // Return a book to the library.
        Book Return(int idBook);

        // Logbooks viewing method.
        void LookAll();
    }
}
