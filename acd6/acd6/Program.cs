using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var expressions = new List<Expression>();
                expressions.Add(new Expression(4, 9, 5));
                expressions.Add(new Expression(-1, 7, -2));
                expressions.Add(new Expression(3, -2, 1));
                foreach (var item in expressions)
                {
                    Console.WriteLine(item.GetTheResultExpression());
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Unreal get result. Please, check your input variables.");
            }
        }
    }
}
