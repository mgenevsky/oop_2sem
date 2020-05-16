using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AtheneumLibrary
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public string author { get; set; }
        public string name { get; set; }
        public string genre { get; set; }
        public int IdBook { get; set; }


        public override string ToString()
        {
            return "Id: "+ IdBook + "   Название: " + name + "   Жанр: " + genre + "   Автор: " + author;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Book objAsBook = obj as Book;
            if (objAsBook == null) return false;
            else return Equals(objAsBook);
        }
        public int CompareTo(Book compareBook)
        {
            if (compareBook == null)
                return 1;

            else
                return this.IdBook.CompareTo(compareBook.IdBook);
        }
        public override int GetHashCode()
        {
            return IdBook;
        }
        public bool Equals(Book other)
        {
            if (other == null) return false;
            return (this.IdBook.Equals(other.IdBook));
        }
    }
}
