using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd2_c
{
    class Program
    {
        static void Main(string[] args)
        {
            Mystring str1 = new Mystring("dhdg");
            Mystring str2 = new Mystring("4u");
            Mystring str3 = new Mystring("1254u");
            Mytext text = new Mytext();

            text.AddString(str1);
            text.AddString(str2);
            text.AddString(str3);
            text.DelString(1);
            Console.WriteLine(text.DigitString()); 
        }
    }
}
