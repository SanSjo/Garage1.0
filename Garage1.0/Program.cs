using System;

namespace Garage1._0
{
    class Program
    {
        static void Main(string[] args)
        {

            //Garage<Vehicle> garage = new Garage<Vehicle>(5);
            //var bil = new Car("bensin", "ABC123", "svart", 4);
            //garage.Add(bil);
            
            ConsoleUI ui = new ConsoleUI();
            var listGarage = "Hur många bilar finns i garaget?";
            ui.Print(listGarage);

            int capacity = int.Parse(ui.GetInput());

            string answer = $"Det finns {capacity} fordon i garaget";
            ui.Print(answer);


            GarageManager manager = new GarageManager(capacity);

            manager.Start();

            



        }
    }
}
