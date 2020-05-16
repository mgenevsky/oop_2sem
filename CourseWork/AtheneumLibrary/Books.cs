using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AtheneumLibrary
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        // Book author.
        public string author { get; set; }

        // Book name.
        public string name { get; set; }
        
        // Book genre.
        public string genre { get; set; }

        // Book Id.
        public int IdBook { get; set; }

        // Ctor.
        public Book() { }

        // Overloaded Ctor.
        public Book(string name, string author, string genre)
        {
            this.name = name;
            this.author = author;
            this.genre = genre;
        }

        // Overloaded method outputing Book.
        public override string ToString()
        {
            return "Id: " + IdBook + "\tName: " + name + "\tGenre: " + genre + "\tAuthor: " + author;
        }

        // Overloaded Book equals method.
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Book objAsBook = obj as Book;
            if (objAsBook == null) return false;
            else return Equals(objAsBook);
        }

        // Book comparison method.
        public int CompareTo(Book compareBook)
        {
            if (compareBook == null)
                return 1;

            else
                return this.IdBook.CompareTo(compareBook.IdBook);
        }

        //Metod that return IdBook.
        public override int GetHashCode()
        {
            return IdBook;
        }

        // Book equals method.
        public bool Equals(Book other)
        {
            if (other == null) return false;
            return (this.IdBook.Equals(other.IdBook));
        }
    }
}
