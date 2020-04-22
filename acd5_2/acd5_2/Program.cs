using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = new MyString("щузьпизуцЗЩПЫЬПЩЗшцйп");
            var str2 = new MySmallLetters("ПЗщшВЫМиуйЧЩФО");
            var str3 = new MyCapitalLetters("ОИМЗупшцрЩШПТШцп");
            Console.WriteLine("Длинна строчки 1 - " + str1.GetLength());
            str1.Sort();
            Console.WriteLine("Длинна строчки 2 - " + str2.GetLength());
            str2.Sort();
            Console.WriteLine("Длинна строчки 3 - " + str3.GetLength());
            str3.Sort();
        }
    }
}
