using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd3_C
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 7, 15 };
            MyArray Arr = new MyArray(arr);

            //Console.WriteLine(Arr[4]);
            Console.WriteLine(Arr[1]);
            int size = Arr.Size;
            Console.WriteLine(size);
        }
    }
}
