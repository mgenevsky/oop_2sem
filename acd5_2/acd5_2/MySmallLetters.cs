using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd5_2
{
    public class MySmallLetters : MyString
    {
        char[] Str;
        public MySmallLetters(string str) : base(str)
        {
            string s;
            s = str?.ToLower();
            Str = s.ToCharArray();
        }
        public override int GetLength()
        {
            return Str.Length;
        }
        public override void Sort()
        {
            Array.Sort(Str);
            Array.Reverse(Str);
            Console.WriteLine(Str);
        }
    }
}
