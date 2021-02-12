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
        public int Capacity { get; set; }
        public GarageManager(int capacity)
        {
            garageHandler = new GarageHandler(capacity);
            Capacity = capacity;
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
                        ui.ExitGarage();
                        break;
                    default:
                        ui.Print("Wrong inout! You must enter 1, 2, 3, 4, 5 or 0");
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
                    default:
                        ui.Print("Wrong input! You must enter 1, 2 or 3.");
                        break;

                }


            } while (searchDone);


            if (CheckForNull(vehiclesList))
            {
                ui.Print("No vehicles was found");
            }
            else
            {
                var filterByProperties = vehiclesList.Where(v => v?.Color == inputColor || v?.NrOfWheels == inputWheels || v?.GetType().Name == inputType);


                foreach (var item in filterByProperties)
                {
                    if (CheckForNull(vehiclesList))
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

        private void SearchByRegNumber()
        {
            var vehicleList = garageHandler.filterGarage.vehicles;

            ui.Print("Search registration number:");
            string regNumberInput = ui.GetInput();

            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList == null)
                {
                    ui.Print("No match found");
                }
                else
                {
                    if (Capacity > 3)
                    {
                        ui.Print("No match found");
                    }
                    else
                    {

                        if (vehicleList[i].RegNumber.ToLower() == regNumberInput.ToLower() || vehicleList[i].RegNumber.ToUpper() == regNumberInput.ToUpper())
                        {
                            ui.Print($"We found {vehicleList[i].RegNumber} that is a {vehicleList[i].GetType().Name} with color of {vehicleList[i].Color}");
                        }
                    }
                }
            }
        }

        public void RemoveVehicle()
        {
            var deleteVehicle = garageHandler.filterGarage.vehicles;
            //Garage<Vehicle> list = new Garage<Vehicle>(Capacity);

            //List<Vehicle[]> array = new List<Vehicle[]>(Capacity);
            //int Reg = int.Parse(ui.GetInput());
            //array.RemoveAt(Reg);

            //int diff = 0;
            //int currentValue = 0;

            //for (int i = 0; i < list.Length; i++)
            //{
            //    _ = Reg is Vehicle[];
            //    if (list[i] == null && list[i] == _)
            //    {
            //        diff += 1;
            //    }
            //}
            //Vehicle[] newArray = new Vehicle[list.Length - diff];
            //for (int i = 0; i < list.Length; i++)
            //{
            //    if(list.Length != Reg)
            //    {
            //        newArray[currentValue] = list[i];
            //        currentValue += 1;
            //    }
            //}
            //ui.Print($"This is {newArray}");
            //Vehicle[] newArray = new Vehicle[list.Length - 1];
            //if (index > 0)
            //{
            //    Array.Copy(list, 0, newArray, 0, index);
            //}
            //if (index < list.Length - 1)
            //{
            //    Array.Copy(list, index + 1, newArray, index, list.Length - index - 1);
            //}

            //return newArray
            

            int indexInt = int.Parse(ui.GetInput());
            deleteVehicle = deleteVehicle.Where((source, index) => index != indexInt).ToArray();
            var deletedItem = deleteVehicle[indexInt].GetType().Name;
            ui.Print(deletedItem);
            for (int i = 0; i < deleteVehicle.Length; i++)
            {

                ui.Print($"Left in Garage is {deleteVehicle[i]?.GetType().Name : 'empty spot'}");

            }


        }

        //TODO Hur löser man detta?
        private void RemoveVehicleItem()
        {

            do
            {
                var list = garageHandler.filterGarage.vehicles;
                int inputIndex = int.Parse(ui.GetInput());

                //list.RemoveVehicle(inputIndex);
                ui.Print($"newlist {list}");
            } while (true);




            //var remove = new List<Vehicle>(Capacity);

            //string inputReg = ui.GetInput();


            //foreach (var item in remove)
            //{

            //}
            //remove.RemoveAt(inputIndex);
            //remove.RemoveVehicle(inputIndex);
            //veLit.RemoveAt(inputReg);

            //for (int i = 0; i < veLit.Count; i++)
            //{

            //    if (veLit[i].RegNumber == inputReg)
            //    {
            //        veLit.Remove(veLit[i]);

            //    }
            //}

            //Console.WriteLine(list);
            ////list = list.Where 
            //bool enterCountVehicles = true;

            ////int indexToRemove = inputIndex;
            //int count = CountVehicles();
            //if (count <= indexToRemove)
            //{
            //    list[indexToRemove - 1] = null;
            //    enterCountVehicles = false;
            //}
            //if (list.Length < 1)
            //{
            //    ui.Print("Garage is already empty");

            //}

            //return enterCountVehicles;
        }



        public void AddVehicleByOption()
        {
            var list = garageHandler.filterGarage.vehicles;
            if (list.Length <= 0)
            {
                ui.Print("Garage is empty");
            }
            else
            {
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
            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] != null)
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
            var vehicles = new Garage<Vehicle>(Capacity);


            // ui.PrintVehicle(list.Length);

            foreach (Vehicle item in list)
            {
                if (item == null)
                {

                    var countLeft = list.Length - Capacity;
                    ui.Print($"You can add  vehicles");
                }
                else
                {
                    string basicString = $"{item.GetType().Name} has reg.number {item.RegNumber}, the color {item.Color} and have {item.NrOfWheels} wheels and ";

                    if (item is Airplane)
                    {

                        var plane = item as Airplane;
                        airplaneCount++;
                        //TODO nrof engines not printed, WHY!
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
            CountParkedVehicles(airplaneCount, "Airplane");
            CountParkedVehicles(carCount, "Car");
            CountParkedVehicles(boatCount, "Boat");
            CountParkedVehicles(motorCycleCount, "Motorcycle");
            CountParkedVehicles(busCount, "Bus");
            int AllVehicles = airplaneCount + carCount + motorCycleCount + busCount + boatCount;
            ui.Print($" There are in total {AllVehicles} vehicles in the garage");





            //garageHandler.ListAllVehicles(g => ui.Print(g + "this is a new veihicek"));
        }



    }
}