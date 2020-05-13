using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace acd8
{
    class Program
    {
        static void Main(string[] args)
        {
            Car BMW = new Car("BMW");
            BMW.OutOfFuel += Display;
            Car Audi = new Car("Audi");
            Audi.OutOfFuel += Display;
            Car Ferrari = new Car("Ferrari");
            Ferrari.OutOfFuel += Display;
            BMW.MoveStart();
            Audi.MoveStart();
            Ferrari.MoveStart();
            Ferrari.Move();
            Audi.Move();
            Ferrari.Move();
        }

        static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
