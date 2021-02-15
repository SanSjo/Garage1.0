using System;

namespace Garage1._0
{
    public class CreateGarage
    {
        private GarageManager garageManager;

        public void CreateNewGarage()
        {
            var listGarage = "There are 3 vehicles in the garage, how many parking spots do you want?";
            System.Console.WriteLine(listGarage);

            int capacity = int.Parse(Console.ReadLine());
           
        }

    }
}