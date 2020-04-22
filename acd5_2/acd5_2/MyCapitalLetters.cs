using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd5_2
{
    public class MyCapitalLetters : MyString
    {
        char[] Str;
        public MyCapitalLetters(string str) : base(str)
        {
            string s;
            s = str?.ToUpper();
            Str = s.ToCharArray();
        }
        public override int GetLength()
        {
            return Str.Length;
        }
        public override void Sort()
        {
            Array.Sort(Str);
            Console.WriteLine(Str);
        }
    }
}
