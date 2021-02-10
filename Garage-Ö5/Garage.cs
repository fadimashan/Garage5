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
            capacity = Math.Max(0, capacity);
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

            return false;
        }

        public bool CheckIfThereIsNull()
        {
            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] == null)
                {
                    return true;
                }
            }
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
