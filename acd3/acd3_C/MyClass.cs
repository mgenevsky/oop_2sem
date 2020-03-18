using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd3_C
{
    class MyClass
    {
        private MyClass()
        {
            private int[] numbers = new int[] { 1, 2, 4 };
        }   
        public int this[int i, int j]
        {
            get
            {
                return numbers[i, j];
            }
            set
            {
                numbers[i, j] = value;
            }

        }
    }
}
}
