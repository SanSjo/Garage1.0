using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Garage1._0
{

    internal class GarageManager
    {
        ConsoleUI ui = new ConsoleUI();

        public int count = 0;

        GarageHandler garageHandler;
        public GarageManager(int capacity)
        {
            garageHandler = new GarageHandler(capacity);
        }

        internal void Start()
        {
            do
            {
                string menuMessage = "Välj vad du vill göra i garaget genom att välja menyval 1, 2, 3, 4 eller 0 för att avsluta"
                    + "\n1. Lägg till ett fordon"
                    + "\n2. Ta bort ett fordon"
                    + "\n3. Hitta ett fordon med registreringsnummer"
                    + "\n4. Sök efter fordon"
                    + "\n5. Skriv ut alla fordon i garaget"
                    + "\n0. Avsluta programmet";

                ui.Print(menuMessage);
                string nav = ui.GetInput();

                switch (nav)
                {
                    case "1":
                        AddVehicleByOption();
                        //AddAirplane();
                        break;
                    case "2":
                        RemoveVehicle();
                        break;
                    case "3":
                        SearchByRegNumber();
                        break;
                    case "4":
                        SearchForVehicle();
                        break;
                    case "5":
                        ListParkedVehicles();
                        //garageHandler.filterGarage.GetEnumerator();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                }

            } while (true);

        }

        private void SearchForVehicle()
        {
            var vehiclesList = garageHandler.filterGarage.vehicles;
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
                    case "4":
                        
                        break;

                }


            } while (searchDone);


            //SearchResult(vehiclesList, inputType, inputColor, inputWheels);
            //TODO Fix errormeddelande nullexceptions
            if (vehiclesList == null)
            {
                ui.Print("No vehicles was found");
            }
            else
            {
                var filterByProperties = vehiclesList.Where(v => !string.IsNullOrEmpty(inputType) && v.Color == inputColor || (inputWheels != -1 && v.NrOfWheels == inputWheels) || !string.IsNullOrWhiteSpace(inputType) && v.GetType().Name == inputType);

                foreach (var item in filterByProperties)
                {
                    if (filterByProperties == null)
                    {
                        ui.Print("No items found");
                    }
                    else
                    {
                        ui.Print($"We found {item.GetType().Name} with color {item.Color} and {item.NrOfWheels} wheels");
                    }
                }
            }



            //var filterByColorandWheels = vehiclesList.Where(v => v.Color == inputColor || v.NrOfWheels == inputWheels || v.GetType().Name == inputType);

        }

        

        private void SearchByRegNumber()
        {
            var vehicleList = garageHandler.filterGarage.vehicles;

            string regNumberInput = ui.GetInput();

            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i].RegNumber.ToLower().ToUpper() == regNumberInput)
                {
                    ui.Print($"We found {vehicleList[i].RegNumber} that is a {vehicleList[i].GetType().Name} with color of {vehicleList[i].Color}");
                }
            }
        }

        //TODO Hur löser man detta?
        private bool RemoveVehicle()
        {
            var list = garageHandler.filterGarage.vehicles;
            
            Console.WriteLine(list);
            //list = list.Where 
            int inputIndex = int.Parse(ui.GetInput());
            bool enterCountVehicles = true;

            int indexToRemove = inputIndex;
            int count = CountVehicles();
            if(count <= indexToRemove)
            {
                list[indexToRemove -1] = null;
                enterCountVehicles = false;
            }
            if(list.Length < 1)
            {
                ui.Print("Garage is already empty");

            }

            return enterCountVehicles;
        }

       

        public void AddVehicleByOption()
        {
            var list = garageHandler.filterGarage.vehicles;
            if (list.Length <= 0)
            {
                ui.Print("Garage is empty");
            } 
            else { 
            ui.Print("Välj vilket fordon du vill lägga till? " 
                + "\n1. Airplane "
                + "\n2. MotorCycle"
                + "\n3. Car"
                + "\n4. Bus"
                + "\n5. Boat");

            string option = ui.GetInput();

            switch (option)
            {
                case "1":
                    garageHandler.AddAirplane();
                    break;
                case "2":
                    garageHandler.AddMotorcycle();
                    break;
                case "3":
                    garageHandler.AddCar();
                    break;
                case "4":
                    garageHandler.AddBus();
                    break;
                case "5":
                    garageHandler.AddBoat();
                    break;
                    
            }
            }
        }

        
        public int CountVehicles()
        {
            count = 0;
            var vehicleList = garageHandler.filterGarage.vehicles;
            for(int i = 0; i < vehicleList.Length; i++)
            {
                if(vehicleList[i] != null)
                {
                    count++;
                }
            }
            return count;
        }

        public void CountParkedVehicles(int vehicleItem, string vehicleType)
        {

            if (vehicleItem > 0)
            {
                ui.Print($"{vehicleItem} {vehicleType} in the garage");
            }
        }
        private void ListParkedVehicles()
        {

            int airplaneCount = 0;
            int carCount = 0;
            int motorCycleCount = 0;
            int busCount = 0;
            int boatCount = 0;
            //int planes = 0;
            var list = garageHandler.filterGarage.vehicles;
            // ui.PrintVehicle(list.Length);

            foreach (Vehicle item in list)
            {
                string basicString = $"{item.GetType().Name} has reg.number {item.RegNumber}, the color {item.Color} and have {item.NrOfWheels} wheels and ";

                if (item != null)
                {
                    if (item is Airplane)
                    {
                        
                        var plane = item as Airplane;
                        airplaneCount++;
                       
                            ui.Print($"{basicString} and {plane.NrOfEngines} engines");
                       
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
            CountParkedVehicles(airplaneCount, "Airplane");
            CountParkedVehicles(carCount, "Car");
            CountParkedVehicles(boatCount, "Boat");
            CountParkedVehicles(motorCycleCount, "Motorcycle");
            CountParkedVehicles(busCount, "Bus");





            //garageHandler.ListAllVehicles(g => ui.Print(g + "this is a new veihicek"));
        }



    }
}