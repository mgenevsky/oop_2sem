using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Car
    {
        public delegate void ClearHandler(string message);
        public event ClearHandler OutOfFuel;
        int fuel = 100;
        string str;
        public Car(string str)
        {
            this.str=str;
        }
        public void MoveStart()
        {
            fuel -= 20;
            Console.WriteLine("Car " + str + " start moving");
        }

        public void MoveEnd()
        {
            Console.WriteLine("Car " + str + " end moving");
        }
        public void Move()
        {
            fuel -= 40;
            if (fuel == 0) {
                if (OutOfFuel != null)
                    OutOfFuel?.Invoke("Car " + str + " out of fuel!");
                else
                    throw new NullReferenceException("Event OutOfFuel must not be null");
            }
            else
                Console.WriteLine("Car " + str + " moving");     
        }
        public void Refill()
        {
            if (fuel <=100)
            {
                if (fuel+50 >=100)
                    fuel = 100;
                else
                    fuel += 50;
            }
            Console.WriteLine("Car " + str + " start refilling");
        }
        public void UseFuel()
        {
            fuel -= 50;
            Console.WriteLine("Car " + str + " start refilling");
        }
    }
}
