using System;

namespace Garage1._0
{
    public class Vehicle
    {
       
        //internal int nrOfWheels;

        //private  string regNumber;
        public string RegNumber
        { get; set;
           
        }
        public string Color { get; set; }
        public int NrOfWheels { get; set; }

        public Vehicle(string regNumber, string color, int nrOfWheels)
        {
            RegNumber = regNumber;
            Color = color;
            NrOfWheels = nrOfWheels; 
        }

     
    }

    public class Airplane : Vehicle
    {
        

        public int NrOfEngines { get; set; }

        //public Airplane(int nrOfEngines, string regNumber, string color, int nrOfWheels) : base(regNumber, color, nrOfWheels)
        //{
        //    NrOfEngines = nrOfEngines;

        //}

        public Airplane( string regNumber, string color, int nrOfWheels, int nrOfEngines) : base(regNumber, color, nrOfWheels)
        {
            NrOfEngines = nrOfEngines;
        }
       
    }

    class MotorCycle : Vehicle
    {
        public double  CylinderVolume { get; set; }
        public MotorCycle( string regNumber, string color, int nrOfWheels, double cylinderVolume) : base(regNumber, color, nrOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }

       
    }
    public class Car : Vehicle
    {
        public string FuelType { get; set; }
        public Car( string regNumber, string color, int nrOfWheels, string fuelType) : base(regNumber, color, nrOfWheels)
        {
            FuelType = fuelType;
        }

      

      
    }

    public class Bus : Vehicle
    {
        public int NrOfSEats { get; set; }

        public Bus( string regNumber, string color, int nrOfWheels, int nrOfSeats) : base(regNumber, color, nrOfWheels)
        {
            NrOfSEats = nrOfSeats;
        }

        public Bus(string regNumber, string color, int nrOfWheels, string nrOfSeats) : base(regNumber, color, nrOfWheels)
        {
        }
    }
  
    class Boat : Vehicle
    {
        public double Length { get; set; }

        public Boat( string regNumber, string color, int nrOfWheels, double length) : base(regNumber, color, nrOfWheels)
        {
            Length = length;
        }

        public Boat(string regNumber, string color, int nrOfWheels, string length) : base(regNumber, color, nrOfWheels)
        {
        }

        public Boat(string regNumber, string color, int nrOfWheels, int length) : base(regNumber, color, nrOfWheels)
        {
        }
    }
}