using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    class Book
    {
        static int bookcounter = 0;
        public string genre { get; private set; }
        public string name { get; private set; }
        public string author { get; private set; }
        public int IdBook { get; private set; }
        public Book(string genre, string name,string author)
        {
            this.genre = genre;
            this.name = name;
            this.author = author;
            IdBook = ++bookcounter;
        }
    }
}
