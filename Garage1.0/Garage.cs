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

        public int Count { get; set; }
      
        public bool IsFull 
        { 
            get
            {
                return Capacity == Count;
            }
           
        }

        public Garage(int capacity)
        {
            Capacity = Math.Max(0, capacity);
            vehicles = new T[capacity];
           
        }

        public bool Add(T vehicleItem)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if(vehicles[i] == null)
                {
                    vehicles[i] = vehicleItem;
                    ui.Print(" ");
                    ui.Print($"Your {vehicleItem.GetType().Name} is parked");
                    ui.Print(" ");
                    return true;
                }
                else if(Capacity < vehicles.Length)
                {
                    ui.Print("Sorry, the garage is full");
                }
            }
            return false;
        }

        

        public IEnumerator<T> GetEnumerator()
        {

            foreach (var item in vehicles)
            {
                //TODO nullcheck om item is null 
                ui.PrintVehicle(item);
                yield return item;
                
                
            }

        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}