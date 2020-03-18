using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd3_C
{
    class MyArray
    {
        private int size;
        private int[] Arr = new int[] { };
        public MyArray(int[] arr)
        {
            Arr = arr;
            size = arr.Length;
        }

        public int this[int index]
        {
            set
            {
                if (index > size)
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    Arr[index] = value;
                }

            }
            get
            {
                if (index > size)
                {
                    Console.WriteLine("Error");
                    return 0;
                }
                else
                {
                    return Arr[index];
                }
            }

        }
        public int Size
        {
            get
            {
                return size;
            }
        }

    }
}
