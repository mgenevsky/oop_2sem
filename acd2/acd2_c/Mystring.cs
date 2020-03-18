using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd2_c
{
    class Mystring
    {
        char[] Str;

        public Mystring(string str)
        {
            Str = str.ToCharArray();
        }
        public string Numbers()
        {
            String str = "";
            for (int i = 0; i < Str.Length; i++)
            {
                if (char.IsDigit(Str[i]))
                {
                    str += Str[i];
                }
            }
            return str;
        }
    }
}
