using System;
using System.Collections.Generic;

namespace Garage1._0
{
    public class GarageHandler
    {

        //Garage<Vehicle> filterGarage = new Garage<Vehicle>(3);

        //List<Vehicle> listVehicles = new List<Vehicle>(3);
        readonly ConsoleUI ui = new ConsoleUI();
        public Garage<Vehicle> filterGarage;
        int garageCapacity = 0;
        public GarageHandler(int capacity)
        {

            filterGarage = new Garage<Vehicle>(capacity);
            garageCapacity = capacity;
        }

        public Garage<Vehicle> ListAllVehicles()
        {
            return filterGarage;
        }



        public void AddAirplane()
        {

            var vehicles = AddVehicle();
            ui.Print("Antal motorer?");
            int nrOfEngines = int.Parse(ui.GetInput());
            var plane = new Airplane(vehicles.RegNumber, vehicles.Color, vehicles.NrOfWheels, nrOfEngines);
            filterGarage.Add(plane);

        }

        public void AddCar()
        {

            var vehicles = AddVehicle();

            ui.Print("Bensintyp?");
            string fuelType = ui.GetInput();
            var car = new Car(vehicles.RegNumber, vehicles.Color, vehicles.NrOfWheels, fuelType);
            filterGarage.Add(car);



        }
        public void AddBoat()
        {
            var vehicles = AddVehicle();

            ui.Print("Length on boat?");
            int length = int.Parse(ui.GetInput());
            var boat = new Boat(vehicles.RegNumber, vehicles.Color, vehicles.NrOfWheels, length);
            filterGarage.Add(boat);
        }

        public void AddBus()
        {
            var vehicles = AddVehicle();

            ui.Print("Number of seats?");
            int nrOfSeats = int.Parse(ui.GetInput());
            var bus = new Bus(vehicles.RegNumber, vehicles.Color, vehicles.NrOfWheels, nrOfSeats);
            filterGarage.Add(bus);
        }

        public void AddMotorcycle()
        {

            var vehicles = AddVehicle();

            ui.Print("Cylinder Volume?");
            double cylinderVolume = int.Parse(ui.GetInput());
            var motorCycle = new MotorCycle(vehicles.RegNumber, vehicles.Color, vehicles.NrOfWheels, cylinderVolume);
            filterGarage.Add(motorCycle);
        }

        public Vehicle AddVehicle()
        {

            var vehicle = new Vehicle();
            ui.Print("RegNummer");

            string regNumber = ui.GetInput();
            RegistrationNumber(vehicle, regNumber);


            ui.Print("Color");
            string color = ui.GetInput();
            ui.Print("Antal hjul");
            int nrOfWheels = int.Parse(ui.GetInput());


            return new Vehicle(regNumber, color, nrOfWheels);


        }

        //TODO fixa så att man inte loopar igenom addvehicle två gånger
        public bool RegistrationNumber(Vehicle vehicle, string regNumber)
        {

            string unique = regNumber;
            var vehicleList = filterGarage.vehicles;

            for (int i = 0; i < vehicleList.Length; i++)
            {
                
                if (vehicleList[i] != null)
                {
                    if (regNumber.Length < 6 || vehicleList[i].RegNumber != regNumber)
                    {

                        vehicleList[i].RegNumber = regNumber;
                    }
                    else
                    {
                        ui.Print("RegNumber must be unique and include 6 charachters");
                        break;
                        
                    }
                }
            }

            if (regNumber.Length < 6)
            {
                ui.Print("RegNumber must be unique and include 6 charachters");
                return false;
            }
            else
            {
                vehicle.RegNumber = regNumber;
            }


            //if (regNumber.Length == 6 && regNumber != )
            //{
            //    vehicle.RegNumber = regNumber;
            //}


            return false;
        }



        //public void AddVehicle<T>(T item) 
        //{
        //    filterGarage.Add(item as Vehicle);
        //}



        public void LoopVehicles()
        {


        }



    }
}