using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1._0
{
    class ConsoleUI
    {

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        //public void PrintList()
        //{
        //    Console.WriteLine();
        //}

        internal void PrintVehicle(int item)
        {
            Console.WriteLine(item);
        }

        public void PrintVehicle(Vehicle item)
        {
            //Console.WriteLine(item);
            Console.WriteLine(item);
        }
    }
}
