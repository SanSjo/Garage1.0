using System;
using System.Collections;
using System.Collections.Generic;

namespace Garage1._0
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        ConsoleUI ui = new ConsoleUI();
        public int Capacity { get; set; }
        
        public T[] vehicles;

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
            Capacity = Math.Max(0, capacity);
            vehicles = new T[capacity];
            Count = CountVehicles();
            
           
        }

        public bool Add(T vehicleItem)
        {
            
            for (int i = 0; i < vehicles.Length; i++)
            {
                count = 0;
                if(vehicles[i] == null)
                {
                    vehicles[i] = vehicleItem;
                    ui.Print(" ");
                    ui.Print($"Your {vehicleItem.GetType().Name} is parked");
                    ui.Print(" ");
                    
                    return false;
                }
                 else if (vehicles[i] != null)
                {
                    count++;
                    ui.Print("Sorry, the garage is full");
                    
                }
                

            }
            
            return true;
        }

        public T[] RemoveVehicle(int index)
        {
            T[] newArray = new T[vehicles.Length - 1];
            if(index > 0)
            {
                Array.Copy(vehicles, 0, newArray, 0, index);
            }
            if (index < vehicles.Length -1 )
            {
                Array.Copy(vehicles, index + 1, newArray, index, vehicles.Length - index - 1);
            }

            return newArray;
        }
        public int CountVehicles()
        {
            count = 0;
            var vehicleList = vehicles;
            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] != null)
                {
                    count++;
                }
            }
            return count;
        }



        public IEnumerator<T> GetEnumerator()
        {

            foreach (var item in vehicles)
            {
                
                if (item != null)
                {
                    ui.PrintVehicle(item);
                    yield return item;
                }
                
                
                
            }

        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}