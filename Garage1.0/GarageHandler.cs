using System;
using System.Collections.Generic;

namespace Garage1._0
{
    public class GarageHandler
    {

        //Garage<Vehicle> filterGarage = new Garage<Vehicle>(3);

        //List<Vehicle> listVehicles = new List<Vehicle>(3);
        readonly IUI ui = new ConsoleUI();

        public Garage<Vehicle> filterGarage;



        int garageCapacity = 0;
        public int count = 0;
        public GarageHandler(int capacity)
        {

            filterGarage = new Garage<Vehicle>(capacity);
            garageCapacity = capacity;
            
            count = filterGarage.CountVehicles();
        }

        public Garage<Vehicle> ListAllVehicles()
        {
            return filterGarage;
        }








        //if (regNumber.Length == 6 && regNumber != )
        //{
        //    vehicle.RegNumber = regNumber;
        //}





        //public void AddVehicle<T>(T item) 
        //{
        //    filterGarage.Add(item as Vehicle);
        //}







    }
}