using System;

namespace Garage1._0
{
    public class CreateGarage
    {
        private GarageManager garageManager;

        public void CreateNewGarage()
        {
            var listGarage = "There are 3 vehicles in the garage, how many parking spots do you want?";
            System.Console.WriteLine(listGarage);

            int capacity = int.Parse(Console.ReadLine());
            //garageManager = new GarageManager(capacity);

            //Start(capacity);

        }

       // public int Start(int capacity)
       // {
       //     //ToDo
       // //garageHandler = new GarageHandler(capacity);
       //// GarageManager garage = new GarageManager(capacity);
            

       //     do
       //     {
       //         string menuMessage = "Välj vad du vill göra i garaget genom att välja menyval 1, 2, 3, 4 eller 0 för att avsluta"
       //             + "\n1. Lägg till ett fordon"
       //             + "\n2. Ta bort ett fordon"
       //             + "\n3. Hitta ett fordon med registreringsnummer"
       //             + "\n4. Sök efter fordon"
       //             + "\n5. Skriv ut alla fordon i garaget"
       //             + "\n0. Avsluta programmet";

       //         Console.WriteLine(menuMessage);
       //         string nav = Console.ReadLine();

       //         switch (nav)
       //         {
       //             case "1":
       //                 if (capacity == garage.Count)
       //                 {
       //                     Console.WriteLine("Garage is now full");
       //                 }
       //                 else
       //                 {
       //                     garage.AddVehicleByOption();

       //                 }
       //                 //AddAirplane();
       //                 break;
       //             case "2":
       //                 garage.RemoveItem();
       //                 break;
       //             case "3":
       //                 garage.SearchByRegNumber();
       //                 break;
       //             case "4":
       //                 garage.SearchForVehicle();
       //                 break;
       //             case "5":
       //                 garage.ListParkedVehicles();
       //                 //garageHandler.filterGarage.GetEnumerator();
       //                 break;
       //             case "0":
       //                 ExitGarage();
       //                 break;
       //             default:
       //                 Console.WriteLine("Wrong inout! You must enter 1, 2, 3, 4, 5 or 0");

       //                 break;
       //         }

       //     } while (true);

       // }

        private void ExitGarage()
        {
            throw new NotImplementedException();
        }
    }
}