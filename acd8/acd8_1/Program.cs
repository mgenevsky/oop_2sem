using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd8_1
{
    class Program
    {
        delegate int[] Sort(int[] a);
        static void Main(string[] args)
        {
            int[] a = { 11, 5, 15, 7, 13 };
            int[] b = { 1, 25, 136, 22, 9 };
            Console.WriteLine("a:");
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i]+" ");
            Console.WriteLine();
            Console.WriteLine("b:");
            for (int i = 0; i < b.Length; i++)
                Console.Write(b[i] + " ");
            Sort sort1 = new Sort(SortStatic.Sort);
            sort1.Invoke(a);
            SortObj sort2= new SortObj();
            sort2.Sort(a);
            Console.WriteLine();
            Console.WriteLine("a:");
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
            Console.WriteLine("b:");
            for (int i = 0; i < b.Length; i++)
                Console.Write(b[i] + " ");
            Console.WriteLine();
        }
    }
}
