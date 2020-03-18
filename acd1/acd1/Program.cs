using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Масимка
{
    class Program
    {
        static void Main(string[] args)
        {
            int number, a, b;
            Console.WriteLine("Enter number:");
            number = int.Parse(Console.ReadLine());
            foo1(ref number);
            Console.WriteLine("Answer:" + number);
            Console.WriteLine("Enter two numbers:");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            bool answer = foo2(a, b);
            Console.WriteLine("Answer:" + answer);

        }
        public static void foo1(ref int number)
        {
            int temp = 1;
            while (Convert.ToBoolean(number & temp))
            {
                number ^= temp;
                temp = temp << 1;
            }
            number ^= temp;
        }
        public static bool foo2(int a, int b)
        {
            bool output = false;
            char res = '=';
            if (!Convert.ToBoolean(a >> 31) && !Convert.ToBoolean(b >> 31))
            {
                for (int i = sizeof(int) * 8 - 1; i >= 0; --i)
                {
                    int z = 1 << i;
                    res = res == '=' ? (
                        Convert.ToBoolean(a & z ^ b & z) ? (Convert.ToBoolean(a & z) ? '>' : '<') : '='
                    ) : res;
                }
            }
            else if (Convert.ToBoolean(a >> 31) && Convert.ToBoolean(b >> 31))
            {
                for (int i = sizeof(int) * 8 - 1; i >= 0; --i)
                {
                    int z = 1 << i;
                    res = res == '=' ? (
                        Convert.ToBoolean(~a & z ^ ~b & z) ? (Convert.ToBoolean(~a & z) ? '<' : '>') : '='
                    ) : res;
                }
            }
            else if (!Convert.ToBoolean(a >> 31) && Convert.ToBoolean(b >> 31)) res = '>'; else res = '<';
            Console.WriteLine("{0} {1} {2}", a, res, b);
            output = (res == '=') ? (false) : (res == '>' ? true : false);
            return output;
        }
    }
}