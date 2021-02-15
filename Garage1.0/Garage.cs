using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Garage1._0
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        //private IUI ui = new ConsoleUI();
        //ToDo
        //  private IHandler garageHandler;
        public int Capacity => vehicles.Length;

        private T[] vehicles;

        //ToDo
        // vehicles[i] = null;
        public T[] Vehicles
        {
            get { return vehicles; }
            //ToDo
            set { vehicles = value; }
        }

        public int VehicleLength;

        private int count = 0;

        public int Count => count;

        public bool IsFull()
        {        
            return Capacity == Count;
        }

        public Garage(int capacity)
        {
  
            Vehicles = new T[capacity];
            //count = CountVehicles();
            VehicleLength = vehicles.Length;
        }

        public bool Add(T vehicleItem)
        {

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicleItem;
                    count++;

                    return true;
                }
               
            }

            return false;
        }

        public void Remove(int index)
        {
            vehicles[index] = null;
            count--;
        }


        //public T[] RemoveItem(int index)
        //{
        //    T[] newArray = new T[vehicles.Length - 1];
        //    if (index > 0)
        //    {
        //        Array.Copy(vehicles, 0, newArray, 0, index);
        //    }
        //    if (index < vehicles.Length - 1)
        //    {
        //        Array.Copy(vehicles, index + 1, newArray, index, vehicles.Length - index - 1);
        //    }

        //    return newArray;
        //}
        public int CountVehicles()
        {
            var Count = 0;
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
                    //ToDo
                    // Console.WriteLine(item);
                    yield return item;
                }
            }
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}