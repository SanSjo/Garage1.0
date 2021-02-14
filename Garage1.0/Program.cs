using System;

namespace Garage1._0
{
    class Program
    {
        static void Main(string[] args)
        {

            //Garage<Vehicle> garage = new Garage<Vehicle>(5);
            //var bil = new Car("bensin", "ABC123", "svart", 4);
            //garage.Add(bil);

          
                

                //var listGarage = "There are 3 vehicles in the garage, how many parking spots do you want?";
                //Console.WriteLine(listGarage);

                //int capacity = int.Parse(Console.ReadLine());


                //if (capacity < 0)
                //{
                //    Console.WriteLine("No parkings available");
                //}
                //else
                //{
                //    string answer = $"There are {capacity} parkings";
                //    Console.WriteLine(answer);
                //}


                // GarageManager newGarage = new GarageManager(capacity)
                //newGarage.Start();


            IUI ui = new ConsoleUI();
            ui.CreateNewGarage();



        }
    }
}
