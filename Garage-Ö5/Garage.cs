using LimitedList;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Garage_Ö5
{


   public class Garage<T> : IEnumerable<T> where T : Vehicle  
    {
        public T[] vehicleList;
        public Garage(int capacity)
        {
            vehicleList = new T[capacity];
        }

        public bool Add(T item)
        {

            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] == null)
                {
                    vehicleList[i] = item;
                    return true;
                }
            }
            Console.WriteLine("Garage is full");
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in vehicleList)
            {
                if (item != null)
                {
                    Console.WriteLine(item.GetType().Name);
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
