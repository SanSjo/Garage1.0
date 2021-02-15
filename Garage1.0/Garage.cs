using System;
using System.Collections;
using System.Collections.Generic;

namespace Garage1._0
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        //private IUI ui = new ConsoleUI();
        private IHandler garageHandler;
        public int Capacity { get; set; }

        private T[] vehicles;

        public T[] Vehicles
        {
            get { return vehicles; }
            set { vehicles = value; }
        }

        public int VehicleLength;

        public int count = 0;

        public int Count { get; set; }

        public bool IsFull
        {
            get
            {
                return Capacity < Count;
            }

        }

        public Garage(int capacity)
        {
            garageHandler = new GarageHandler(capacity);
            Capacity = capacity;
            Vehicles = new T[capacity];
            Count = CountVehicles();
            VehicleLength = vehicles.Length;
        }

        public bool Add(T vehicleItem)
        {

            //var vehicles = filterGarage.vehicles;

            for (int i = 0; i < vehicles.Length; i++)
            {
                Count = 0;

                if (vehicles[i] == null)

                {
                    vehicles[i] = vehicleItem;
                    if (vehicles[i] != null)
                    //{
                    //    ui.Print(" ");
                    //    ui.Print($"Your {vehicles[i].GetType().Name} is parked");
                    //    ui.Print(" ");
                    //}
                    Count++;

                    return true;
                }
               
            }

            return false;
        }


        public T[] RemoveItem(int index)
        {
            T[] newArray = new T[vehicles.Length - 1];
            if (index > 0)
            {
                Array.Copy(vehicles, 0, newArray, 0, index);
            }
            if (index < vehicles.Length - 1)
            {
                Array.Copy(vehicles, index + 1, newArray, index, vehicles.Length - index - 1);
            }

            return newArray;
        }
        public int CountVehicles()
        {
            Count = 0;
            var vehicleList = vehicles;
            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] != null)
                {
                    Count++;
                }
            }
            return Count;
        }



        public IEnumerator<T> GetEnumerator()
        {

            foreach (var item in vehicles)
            {

                if (item != null)
                {
                    // ui.PrintVehicle(item);
                    Console.WriteLine(item);
                    yield return item;
                }
            }
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}