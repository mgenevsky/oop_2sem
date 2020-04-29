using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd6
{
    class Expression
    {
        public double A { get; set;}
        public double C { get; set;}
        public double D { get; set;}
        public Expression() { }
        public Expression(double a, double c, double d)
        {
            A = a;
            C = c;
            D = d;
        }

        public double GetTheResultExpression()
        {
            if (A == 4)
                throw new DivideByZeroException("Division on Zero!");
            if (A < 0)
                throw new ArithmeticException("Negative square root!");

            return (double)((2 * C - D + Math.Sqrt(23 * A)) / (A / 4 - 1));
        }
    }
}
