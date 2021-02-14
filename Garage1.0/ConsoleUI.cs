using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1._0
{
    class ConsoleUI : IUI
    {

        public void CreateNewGarage()
        {


            var listGarage = "There are 3 vehicles in the garage, how many parking spots do you want?";
            Console.WriteLine(listGarage);

            int capacity = int.Parse(Console.ReadLine());


            if (capacity < 0)
            {
                Console.WriteLine("No parkings available");
            }
            else
            {
                string answer = $"There are {capacity} parkings";
                Console.WriteLine(answer);
            }



            Start(capacity);

        }

        public int Start(int capacity)
        {

            GarageManager manager = new GarageManager(capacity);

            do
            {
                string menuMessage = "Välj vad du vill göra i garaget genom att välja menyval 1, 2, 3, 4 eller 0 för att avsluta"
                    + "\n1. Lägg till ett fordon"
                    + "\n2. Ta bort ett fordon"
                    + "\n3. Hitta ett fordon med registreringsnummer"
                    + "\n4. Sök efter fordon"
                    + "\n5. Skriv ut alla fordon i garaget"
                    + "\n0. Avsluta programmet";

                Console.WriteLine(menuMessage);
                string nav = Console.ReadLine();

                switch (nav)
                {
                    case "1":
                        manager.AddVehicleByOption();
                        //AddAirplane();
                        break;
                    case "2":
                        manager.RemoveVehicle();
                        break;
                    case "3":
                        manager.SearchByRegNumber();
                        break;
                    case "4":
                        manager.SearchForVehicle();
                        break;
                    case "5":
                        manager.ListParkedVehicles();
                        //garageHandler.filterGarage.GetEnumerator();
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

        public string WrongInput(string message)
        {
           return message;
        }

        public void ExitGarage()
        {
            Console.WriteLine("Vill du avsluta?");
            Environment.Exit(0);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        //public void PrintList()
        //{
        //    Console.WriteLine();
        //}

        internal void PrintVehicle(int item)
        {
            Console.WriteLine(item);
        }

        public void PrintVehicle(Vehicle item)
        {
            //Console.WriteLine(item);
            Console.WriteLine(item);
        }
    }
}
