using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd5_2
{
    public class MyString
    {
        char[] Str;
        public MyString(string str)
        {
            Str = str.ToCharArray();
        }

        public virtual int GetLength() => Str.Length;
        public virtual void Sort()
        {
            Array.Sort(Str);
            Console.WriteLine(Str);
        }

    }
}
