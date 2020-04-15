using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd5
{
    class MyLine
    {
        double x1, x2, y1, y2;
        public MyLine(double a, double b, double c, double d)// (0;0) (1;1) //
        {
            x1 = a;
            x2 = c;
            y1 = b;
            y2 = d;
        }
        public double Lenght()
        {
            return Math.Sqrt(((x2 - x1)*(x2 - x1)) + ((y2 - y1)* (y2 - y1)));
        }
    }
}
