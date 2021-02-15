﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Garage1._0
{
    
    public class GarageManager
    {
        private IUI ui;
        private readonly IHandler garageHandler;

        public int Count = 0;

        // public GarageHandler garageHandler;
        CreateGarage createGarage;

        public int Capacity { get; set; }

        public GarageManager(int capacity)
        {
            createGarage = new CreateGarage();
            ui = new ConsoleUI();
            garageHandler = new GarageHandler(capacity);
            //garageHandler = new GarageHandler(capacity);
            Capacity = capacity;
            Count = garageHandler.CountVehicles();
            SeedData(garageHandler.garage, capacity);
            
        }

        public void SeedData(Garage<Vehicle> filterGarage, int capacity)
        {

            if (capacity <= 3)
            {
                ui.Print("The garage is full, add more parkings "); 
                createGarage.CreateNewGarage();
            }

            else
            {
                //filterGarage.Add(new Airplane("ABC123", "White", nrOfWheels: 2, nrOfEngines: 2));
                //filterGarage.Add(new Car("Bensin", "def123", "white", nrOfWheels: 4));
                //filterGarage.Add(new Bus(nrOfSeats: 5, "ghd123", "white", nrOfWheels: 4));
                filterGarage.Vehicles[0] = new Car("def123", "white", nrOfWheels: 4, "Bensin");
                filterGarage.Vehicles[1] = new Bus("ghd123", "white", nrOfWheels: 4, nrOfSeats: 5);
                filterGarage.Vehicles[2] = new Airplane("ABC123", "White", nrOfWheels: 2, nrOfEngines: 2);
                //Count = filterGarage.CountVehicles();

            }

        }

        public void AddVehicleByOption()
        {
            var list = garageHandler.garage.Vehicles;

            ui.Print("Välj vilket fordon du vill lägga till? "
                + "\n1. Airplane "
                + "\n2. MotorCycle"
                + "\n3. Car"
                + "\n4. Bus"
                + "\n5. Boat");

            string option = ui.GetInput();
            if (Capacity == garageHandler.CountVehicles())
            {
                ui.Print("Garage is now full");
            }
            else
            {
                switch (option)
                {
                    case "1":
                        AddAirplane();
                        ui.Print(" ");
                        ui.Print("Airplane is parked");
                        ui.Print(" ");
                        break;
                    case "2":
                        AddMotorcycle();
                        ui.Print(" ");
                        ui.Print("Motorcycle is parked");
                        ui.Print(" ");
                        break;
                    case "3":
                        AddCar();
                        ui.Print(" ");
                        ui.Print("Car is parked");
                        ui.Print(" ");
                        break;
                    case "4":
                        AddBus();
                        ui.Print(" ");
                        ui.Print("Bus is parked");
                        ui.Print(" ");
                        break;
                    case "5":
                        AddBoat();
                        ui.Print(" ");
                        ui.Print("Boat is parked");
                        ui.Print(" ");
                        break;
                    default:
                        ui.WrongInput("Wrong input, you must choose 1, 2, 3, 4 or 5");
                        break;

                }
            }

            //if (list[i] != null)
            //{
            //    ui.Print(" ");
            //    ui.Print($"Your {list[i].GetType().Name} is parked");
            //    ui.Print(" ");
            //}
        }

        public void SearchForVehicle()
        {
            var vehiclesList = garageHandler.garage.Vehicles;
            string inputType = "";
            string inputColor = "";
            int inputWheels = -1;
            string searchMessage = "You can search for a vehicle by printing " +
                "\n1. Search by type" +
                "\n2. Search by color" +
                "\n3: Search by number of wheels" +
                "\n4: Get search result";

            string typeMessage = "What type do you want to serach for?";
            string continueSearch = "Do you want to search for more properties? " +
                "\n1: Yes" +
                "\n2: No, print result";

            bool searchDone = true;
            do
            {
                ui.Print(searchMessage);
                string searchInput = ui.GetInput();

                switch (searchInput)
                {
                    case "1":
                        ui.Print(typeMessage);
                        inputType = ui.GetInput();
                        ui.Print(continueSearch);
                        string continueInput = ui.GetInput();
                        if (continueInput == "1") continue;
                        if (continueInput == "2") searchDone = false;
                        break;
                    case "2":
                        ui.Print(typeMessage);
                        inputColor = ui.GetInput();
                        ui.Print(continueSearch);
                        continueInput = ui.GetInput();
                        if (continueInput == "1") continue;
                        if (continueInput == "2") searchDone = false;
                        break;
                    case "3":
                        ui.Print(typeMessage);
                        inputWheels = int.Parse(ui.GetInput());
                        ui.Print(continueSearch);
                        continueInput = ui.GetInput();
                        if (continueInput == "1") continue;
                        if (continueInput == "2") searchDone = false;
                        break;
                    default:
                        ui.WrongInput("Wrong input! You must enter 1, 2 or 3.");
                        break;

                }


            } while (searchDone);


            if (garageHandler.CheckForNull(vehiclesList))
            {
                ui.Print("No vehicles was found");
            }
            else
            {
                var filterByProperties = vehiclesList.Where(v => v?.Color.ToLower().ToUpper() == inputColor.ToLower().ToUpper() || v?.NrOfWheels == inputWheels || v?.GetType().Name.ToUpper().ToLower() == inputType.ToUpper().ToLower());


                foreach (var item in filterByProperties)
                {

                    ui.Print($"We found {item.GetType().Name} with color {item.Color} and {item.NrOfWheels} wheels");


                }
            }



            //var filterByColorandWheels = vehiclesList.Where(v => v.Color == inputColor || v.NrOfWheels == inputWheels || v.GetType().Name == inputType);

        }

       

        public void SearchByRegNumber()
        {
            var vehicleList = garageHandler.garage.Vehicles;

            ui.Print("Search registration number:");
            string regNumberInput = ui.GetInput();

            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] == null || vehicleList[i].RegNumber == regNumberInput)
                {
                    ui.Print("Registration number not found");
                }

                else
                {

                    if (vehicleList[i]?.RegNumber.ToLower() == regNumberInput.ToLower() || vehicleList[i].RegNumber?.ToUpper() == regNumberInput.ToUpper())
                    {
                        ui.Print($"We found {vehicleList[i].RegNumber} that is a {vehicleList[i].GetType().Name} with color of {vehicleList[i].Color}");
                    }
                    //}
                }
            }
        }

        public void RemoveItem()
        {
            var deleteVehicle = garageHandler.garage.Vehicles;

            int indexInt = int.Parse(ui.GetInput());

            if (Capacity < 3)
            {
                ui.Print("Ni item flund");
            }
            else
            {
                var deletedItemType = deleteVehicle[indexInt].GetType().Name;
                var deletedItemColor = deleteVehicle[indexInt].Color;
                deleteVehicle = deleteVehicle.Where((source, index) => index != indexInt).ToArray();

                ui.Print($"You deleted a {deletedItemColor} {deletedItemType}");
                for (int i = 0; i < deleteVehicle.Length; i++)
                {
                    ui.Print($"Left in Garage is {deleteVehicle[i]?.GetType().Name: 'empty spot'}");
                }
            }

        }



       

        

        public void ListParkedVehicles()
        {

            int airplaneCount = 0;
            int carCount = 0;
            int motorCycleCount = 0;
            int busCount = 0;
            int boatCount = 0;

            //int planes = 0;
            var list = garageHandler.garage.Vehicles;
            var vehicles = new Garage<Vehicle>(Capacity);


            // ui.PrintVehicle(list.Length);

            foreach (Vehicle item in list)
            {
                if (item == null)
                {

                    ui.Print($"Empty parking spot");
                }
                else
                {
                    string basicString = $"{item.GetType().Name} has reg.number {item.RegNumber}, the color {item.Color} and have {item.NrOfWheels} wheels and ";

                    if (item is Airplane)
                    {

                        var plane = item as Airplane;
                        airplaneCount++;
                        ui.Print($"{basicString} {plane.NrOfEngines} engines");

                    }
                    if (item is Car)
                    {
                        var car = item as Car;
                        carCount++;
                        ui.Print($"{basicString} needs {car.FuelType}");
                    }

                    if (item is MotorCycle)
                    {
                        var motorCycle = item as MotorCycle;
                        motorCycleCount++;
                        ui.Print($"{basicString} have a {motorCycle.CylinderVolume} cm cylinder");
                    }
                    if (item is Boat)
                    {
                        var boat = item as Boat;
                        boatCount++;
                        ui.Print($"{basicString} is {boat.Length} long");
                    }
                    if (item is Bus)
                    {
                        var bus = item as Bus;
                        busCount++;
                        ui.Print($"{basicString} have {bus.NrOfSEats} seats");
                    }
                }

            }
            garageHandler.CountParkedVehicles(airplaneCount, "Airplane");
            garageHandler.CountParkedVehicles(carCount, "Car");
            garageHandler.CountParkedVehicles(boatCount, "Boat");
            garageHandler.CountParkedVehicles(motorCycleCount, "Motorcycle");
            garageHandler.CountParkedVehicles(busCount, "Bus");
            int AllVehicles = airplaneCount + carCount + motorCycleCount + busCount + boatCount;
            ui.Print($"There are in total {AllVehicles} vehicles in the garage");
            int parkingsLeft = Capacity - garageHandler.CountVehicles();
            ui.Print($"There are in total {parkingsLeft} empty parkings in the garage");

        }

        public bool Add(IEnumerable<Vehicle> vehicleItem)
        {

            var vehicles = garageHandler.garage.Vehicles;

            for (int i = 0; i < vehicles.Length; i++)
            {
                Count = 0;

                if (vehicles[i] == null)

                {
                    vehicles[i] = (Vehicle)vehicleItem;
                    ui.Print(" ");
                    ui.Print($"Your {vehicleItem.GetType().Name} is parked");
                    ui.Print(" ");
                    Count++;

                    return true;
                }
            }
            return false;
        }

        public void AddAirplane()
        {

            var vehicles = AddVehicle();
            ui.Print("Antal motorer?");
            int nrOfEngines = int.Parse(ui.GetInput());
            var plane = new Airplane(vehicles.RegNumber, vehicles.Color, vehicles.NrOfWheels, nrOfEngines);
            garageHandler.garage.Add(plane);

        }



        public void AddCar()
        {

            var vehicles = AddVehicle();

            ui.Print("Bensintyp?");
            string fuelType = ui.GetInput();
            var car = new Car(vehicles.RegNumber, vehicles.Color, vehicles.NrOfWheels, fuelType);
            garageHandler.garage.Add(car);



        }
        public void AddBoat()
        {
            var vehicles = AddVehicle();

            ui.Print("Length on boat?");
            int length = int.Parse(ui.GetInput());
            var boat = new Boat(vehicles.RegNumber, vehicles.Color, vehicles.NrOfWheels, length);
            garageHandler.garage.Add(boat);
        }

        public void AddBus()
        {
            var vehicles = AddVehicle();

            ui.Print("Number of seats?");
            int nrOfSeats = int.Parse(ui.GetInput());
            var bus = new Bus(vehicles.RegNumber, vehicles.Color, vehicles.NrOfWheels, nrOfSeats);
            garageHandler.garage.Add(bus);
        }

        public void AddMotorcycle()
        {

            var vehicles = AddVehicle();

            ui.Print("Cylinder Volume?");
            double cylinderVolume = int.Parse(ui.GetInput());
            var motorCycle = new MotorCycle(vehicles.RegNumber, vehicles.Color, vehicles.NrOfWheels, cylinderVolume);
            garageHandler.garage.Add(motorCycle);
        }

        public Vehicle AddVehicle()
        {
            ui.Print("RegNummer");
            string regNumber = ui.GetInput();
            garageHandler.RegistrationNumber(regNumber);
            ui.Print("Color");
            string color = ui.GetInput();
            ui.Print("Antal hjul");
            int nrOfWheels = int.Parse(ui.GetInput());
            return new Vehicle(regNumber, color, nrOfWheels);
        }
       


    }
    }