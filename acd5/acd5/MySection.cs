using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd5
{
    class MySection : MyLine
    {
        double x1, y1, x2, y2;
        public MySection(double a, double b,double c,double d) : base(a,b,c,d)// (0;0) (1;1) //
        {
            x1 = a;
            x2 = c;
            y1 = b;
            y2 = d;
        }
        static public double Angle(MySection A, MySection B)
        {
            return Math.Acos(((A.x2 - A.x1) * (A.y2 - A.y1) + (B.x2 - B.x1) * (B.y2 - B.y1)) / (Math.Sqrt(Math.Pow((A.x2 - A.x1), 2) + Math.Pow((B.x2 - B.x1), 2)) * (Math.Sqrt(Math.Pow((A.y2 - A.y1), 2) + Math.Pow((B.y2 - B.y1), 2)))));
        }
        static public double AngleOy(MySection A)
        {
            var Oy = new MySection(0, 0, 0, 1);
            var NewA = new MySection(0, 0, A.x2 - A.x1, A.y2 - A.y1);
            return MySection.Angle(NewA, Oy);
        }
        public string Parameters()
        {
            return "начало (" + x1 + "," + y1 + ") " + "конец (" + x2 + "," + y2 + ")";
        }
    }
}
