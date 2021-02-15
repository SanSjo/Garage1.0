using System.Collections;

namespace Garage1._0
{
     internal interface IHandler 
    {
        public Garage<Vehicle> garage { get; set;  }
        int CountVehicles();
        bool CheckForNull(Vehicle[] vehicleList);
        void CountParkedVehicles(int vehicleItem, string vehicleType);
        //bool RegistrationNumber(string regNumber);

        //void AddAirplane();
        //void AddBoat();
        //void AddBus();
        //void AddCar();
        //void AddMotorcycle();
        //Vehicle AddVehicle();
      
        
       // void SeedData(Garage<Vehicle> filterGarage, int capacity);
    }
}