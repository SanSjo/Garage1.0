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
            //ToDo
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

    }
}