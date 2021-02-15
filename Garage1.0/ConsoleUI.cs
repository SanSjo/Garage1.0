﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1._0
{
    public class ConsoleUI : IUI
    {



        public string WrongInput(string message)
        {
            return message;
        }

        public void ExitGarage()
        {
            Console.WriteLine("Vill du avsluta?");
            Environment.Exit(0);
        }

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
