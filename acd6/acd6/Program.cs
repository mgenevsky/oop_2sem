using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace acd6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var expressions = new List<Expression>();
                //expressions.Add(new Expression(4, 9, 5));
                //expressions.Add(new Expression(-1, 7, -2));
                expressions.Add(new Expression(3, -2, 1));
                foreach (var item in expressions)
                {
                    Console.WriteLine(item.GetTheResultExpression());
                }
            }
            catch (DivideByZeroException ex)
            {
                using (TextWriter tw = new StreamWriter("errors.txt", false))
                {
                    tw.WriteLine(ex.Message);
                }
            }
            catch (ArithmeticException ex)
            {
                using (TextWriter tw = new StreamWriter("errors.txt", false))
                {
                    tw.WriteLine(ex.Message);
                }
            }
            catch (Exception)
            {
                using (TextWriter tw = new StreamWriter("errors.txt", false))
                {
                    tw.WriteLine("Unreal get result. Please, check your input variables.");
                }
            }




        }
    }
}
