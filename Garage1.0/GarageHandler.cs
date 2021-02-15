using System.Collections.Generic;
using System.Linq;

namespace Garage1._0
{
    public class GarageHandler : IHandler
    {
        private int capacity;

        private IUI ui;
        
        public Garage<Vehicle> garage { get; set; }

        CreateGarage createGarage = new CreateGarage();
        int garageCapacity = 0;
        public int count = 0;
        

        public int VehicleLength { get; set; }
        
        public GarageHandler(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
            ui = new ConsoleUI();
            this.capacity = capacity;
            garageCapacity = capacity;
            VehicleLength = garage.Vehicles.Length;
            count = CountVehicles();
        }

        public int CountVehicles()
        {
            count = 0;
            var vehicleList = garage.Vehicles;
            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] != null)
                {
                    count++;
                }
            }
            return count;
        }

        public bool CheckForNull(Vehicle[] vehicleList)
        {
            foreach (var item in vehicleList)
            {
                if (item != null)
                {
                    return false;
                }

            }
            return true;
        }

        public void CountParkedVehicles(int vehicleItem, string vehicleType)
        {

            if (vehicleItem > 0)
            {
                ui.Print($"{vehicleItem} {vehicleType} in the garage");
            }
        }

        public bool RegistrationNumber(string regNumber)
        {


            var vehicleList = garage.Vehicles;

            for (int i = 0; i < vehicleList.Length; i++)
            {

                if (vehicleList[i] != null)
                {
                    //if (regNumber.Length < 6 || vehicleList[i].RegNumber == regNumber)
                    //{

                    //}
                    if (regNumber.Length < 6 || regNumber.Length > 6 || vehicleList[i].RegNumber.ToLower() == regNumber.ToLower())
                    {

                        ui.Print("RegNumber must be unique and include 6 charachters");
                        createGarage.Start(capacity);
                        return false;
                    }
                    //else
                    //{

                    //    vehicleList[i].RegNumber = regNumber;
                    //}


                }


            }
            return true;

            //if (regNumber.Length < 6)
            //{
            //    ui.Print("RegNumber must be unique and include 6 charachters");

            //}
            //else
            //{
            //    vehicle.RegNumber = regNumber;
            //}
            //garageHandler.ListAllVehicles(g => ui.Print(g + "this is a new veihicek"));
        }

        int IHandler.CountVehicles()
        {
            throw new System.NotImplementedException();
        }

        bool IHandler.CheckForNull(Vehicle[] vehicleList)
        {
            throw new System.NotImplementedException();
        }

        void IHandler.CountParkedVehicles(int vehicleItem, string vehicleType)
        {
            throw new System.NotImplementedException();
        }

        bool IHandler.RegistrationNumber(string regNumber)
        {
            throw new System.NotImplementedException();
        }

        //public Garage<Vehicle> ListAllVehicles()
        //{
        //    return garage;
        //}










        //if (regNumber.Length == 6 && regNumber != )
        //{
        //    vehicle.RegNumber = regNumber;
        //}





        //public void AddVehicle<T>(T item) 
        //{
        //    garage.Add(item as Vehicle);
        //}

    }
}