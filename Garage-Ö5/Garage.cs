using LimitedList;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Garage_Ö5
{


   public class Garage<T> : IEnumerable<T> 
    {
        T[] vehicleList;
        public Garage()
        {
            vehicleList = new T[10];
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
            Console.WriteLine("List is full");
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in vehicleList)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
