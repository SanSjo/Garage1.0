using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Garage1._0
{

    public class GarageManager
    {
        private IUI ui;
        private IHandler garageHandler;

        public int Count = 0;

        public int Capacity { get; set; }


        public GarageManager()
        {

            ui = new ConsoleUI();
        }


        public void Start()
        {
            CreateGarage();
            SeedData();
            RunMainMeny();
        }

        private void RunMainMeny()
        {
            {
               
                do
                {
                    string menuMessage = "Välj vad du vill göra i garaget genom att välja menyval 1, 2, 3, 4 eller 0 för att avsluta"
                        + "\n1. Lägg till ett fordon"
                        + "\n2. Ta bort ett fordon"
                        + "\n3. Hitta ett fordon med registreringsnummer"
                        + "\n4. Sök efter fordon"
                        + "\n5. Skriv ut alla fordon i garaget"
                        + "\n6. Skriv ut beläggningsgrad"
                        + "\n0. Avsluta programmet";

                    Console.WriteLine(menuMessage);
                    string nav = Console.ReadLine();

                    switch (nav)
                    {
                        case "1":
                            if (garageHandler.garage.IsFull())
                            {
                                Console.WriteLine("Garage is now full");
                            }
                            else
                            {
                                AddVehicleByOption();

                            }
                     
                            break;
                        case "2":
                            RemoveItem();
                            break;
                        case "3":
                            SearchByRegNumber();
                            break;
                        case "4":
                            SearchForVehicle();
                            break;
                        case "5":
                            ListParkedVehicles();
                            break;
                        case "6":
                            ListNumberOfVehicles();
                            break;
                        case "0":
                            ExitGarage();
                            break;
                        default:
                            Console.WriteLine("Wrong inout! You must enter 1, 2, 3, 4, 5 or 0");

                            break;
                    }

                } while (true);

            }
        }

        

        private void CreateGarage()
        {
            int size;
            bool ok = true;
            do
            {
                //Ask for size
                Console.WriteLine("There are 3 vehicles in the garage, how many parking spots do you want?");
                size = Int32.Parse(Console.ReadLine());
                if (size < 3)
                {
                    Console.WriteLine("Need more than three!");
                }
                else
                {
                    ok = false;
                }

            } while (ok);

            garageHandler = new GarageHandler(size);

        }



        public void SeedData()
        {

            garageHandler.garage.Add(new Car("def123", "white", nrOfWheels: 4, "Bensin"));
            garageHandler.garage.Add(new Bus("ghd123", "white", nrOfWheels: 4, nrOfSeats: 5));
            garageHandler.garage.Add(new Airplane("ABC123", "White", nrOfWheels: 2, nrOfEngines: 2));
        }


        private void ExitGarage()
        {
            throw new NotImplementedException();
        }

        public void AddVehicleByOption()
        {
            var list = garageHandler.garage.Vehicles;

            ui.Print("Välj vilket fordon du vill lägga till? "
                + "\n1. Airplane "
                + "\n2. MotorCycle"
                + "\n3. Car"
                + "\n4. Bus"
                + "\n5. Boat"
                + "\n6 Exit");

            string option = ui.GetInput();
            if (garageHandler.garage.IsFull())
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
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        ui.WrongInput("Wrong input, you must choose 1, 2, 3, 4 or 5");
                        break;
                }
            }
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
        }



        public void SearchByRegNumber()
        {
            var vehicleList = garageHandler.garage.Vehicles;
            ListVehicles();

            ui.Print("Search registration number:");
            string regNumberInput = ui.GetInput();

            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] == null )
                {
                    ui.Print("Registration number not found");
                }
                else
                {

                    if (vehicleList[i].RegNumber == regNumberInput || vehicleList[i]?.RegNumber.ToLower() == regNumberInput.ToLower() || vehicleList[i].RegNumber?.ToUpper() == regNumberInput.ToUpper())
                    {
                        ui.Print($"We found {vehicleList[i].RegNumber} that is a {vehicleList[i].GetType().Name} with color of {vehicleList[i].Color}");
                    }
                }
            }
        }

        public void ListVehicles()
        {
            var deleteVehicle = garageHandler.garage.Vehicles;
            for (int i = 0; i < deleteVehicle.Length; i++)
            {
                if (deleteVehicle[i] != null)
                {
                    ui.Print($"{i}. {deleteVehicle[i].Color} {deleteVehicle[i].GetType().Name} with reg number {deleteVehicle[i].RegNumber} and {deleteVehicle[i].NrOfWheels} wheels");
                }
            }

        }

        public void RemoveItem()
        {
            var deleteVehicle = garageHandler.garage.Vehicles;
            
            ListVehicles();
            ui.Print("Delete vehicle by printing their index number:");            
            int indexInt = int.Parse(ui.GetInput());

            if (deleteVehicle != null || deleteVehicle[indexInt] != null)
            {
                ui.Print($"You deleted a {deleteVehicle[indexInt].Color} {deleteVehicle[indexInt].GetType().Name}");
                garageHandler.garage.Remove(indexInt);

                foreach (var item in garageHandler.garage)
                {
                    ui.Print($"Left in Garage is {item.GetType().Name}.");
                }
            }
            else
            {
                ui.Print("Index does not exist");
            }
        }

        int airplaneCount;
        int carCount;
        int motorCycleCount;
        int busCount;
        int boatCount; 
        public void ListParkedVehicles()
        {
            airplaneCount = 0;
            carCount = 0;
            motorCycleCount = 0;
            busCount = 0;
            boatCount = 0;


            var list = garageHandler.garage.Vehicles;
            var vehicles = new Garage<Vehicle>(Capacity);

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
            

        }

        //public void CountParkedVehicles(int vehicleItem, string vehicleType)
        //{

        //    if (vehicleItem > 0)
        //    {
        //        ui.Print($"{vehicleItem} {vehicleType} in the garage");
        //    }
        //}

        //TODO
        private void ListNumberOfVehicles()
        {
            garageHandler.CountParkedVehicles(airplaneCount, "Airplane");
            garageHandler.CountParkedVehicles(carCount, "Car");
            garageHandler.CountParkedVehicles(boatCount, "Boat");
            garageHandler.CountParkedVehicles(motorCycleCount, "Motorcycle");
            garageHandler.CountParkedVehicles(busCount, "Bus");
            int AllVehicles = airplaneCount + carCount + motorCycleCount + busCount + boatCount;
            ui.Print($"There are in total {AllVehicles} vehicles in the garage");
            int parkingsLeft = garageHandler.garage.Capacity - garageHandler.garage.Count;
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
            RegistrationNumber(regNumber);
            ui.Print("Color");
            string color = ui.GetInput();
            //TODO varningtext pm att man bara kan skriva siffror
            ui.Print("Antal hjul");
            int nrOfWheels = int.Parse(ui.GetInput());
            return new Vehicle(regNumber, color, nrOfWheels);
        }

        public bool RegistrationNumber(string regNumber)
        {
            var vehicleList = garageHandler.garage.Vehicles;

            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] != null)
                {

                    if (regNumber.Length < 6 || regNumber.Length > 6 || vehicleList[i].RegNumber.ToLower() == regNumber.ToLower())
                    {
                        ui.Print("RegNumber must be unique and include 6 charachters");
                        AddVehicleByOption();
                        return false;
                    }
                }
            }
            return true;
        }

    }
}