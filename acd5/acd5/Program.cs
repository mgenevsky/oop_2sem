using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd5
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = new MyLine(1, 6, 1, 2); //(x1,y1,x2,y2);
            Console.WriteLine("Длинна прямой A = " + A.Lenght());
            var B = new MySection(1, 1,3,3); //(x1,y1,x2,y2);
            var C = new MySection(2, 2,4,4); //(x1,y1,x2,y2);
            Console.WriteLine("Угл между отрезками B и C = " + MySection.Angle(B, C)+" радиан ");
            Console.WriteLine("Угл между отрезками B и осью Oy = " + MySection.AngleOy(B) + " радиан ");
            Console.WriteLine("Отрезок C имеет такие координаты - " + C.Parameters());
        }
    }
}
