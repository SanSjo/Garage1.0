using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1._0
{
    class ConsoleUI
    {

        public void CreateNewGarage()
        {
            
            var listGarage = "How many vehicles can park in the garage?";
            Console.WriteLine(listGarage);

            int capacity = int.Parse(Console.ReadLine());

            if(capacity < 0)
            {
                Console.WriteLine("No parkings available");
            }
            else
            {
                string answer = $"There are {capacity} parkings";
                Console.WriteLine(answer);
            }

            

            

            //TODO Seeda och lägg till vehicles i Add metoden. Garage.add lägga till i vehicle listan!! i garagemanager!!
            //GarageHandler garage = new GarageHandler(capacity);
            

            //garage.SeedData(capacity);

            GarageManager manager = new GarageManager(capacity);

            manager.Start();

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
