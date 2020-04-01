using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd4
{
    class Program
    {
        static void Main(string[] args)
        {
            var B1 = new MyVector();
            var B2 = new MyVector(10,45);
            var B3 = new MyVector(B2);
            B2 = B2 / 2;
            B3.Rotation(45);
            B1 = B2 + B3;
            Console.WriteLine(B1.CountLength() + " " + B1.CountCorner());
            Console.WriteLine(B2.CountLength() + " " + B2.CountCorner());
            Console.WriteLine(B3.CountLength() + " " + B3.CountCorner());
        }
    }
}
