using System;
using System.Collections.Generic;
using System.Collections;

namespace Garage_Ö5
{


    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicleList;
        public int counter;
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

        public bool RemoveItem(int input)
        {
          
            T[] tmp = new T[vehicleList.Length];

            // To Delete by registration number
            //for (int i = 0; i < vehicleList.Length; i++)
            //{
            //    if (vehicleList[i] != null)
            //    {
            //        if (vehicleList[i].RegistreringNum.ToLower() == vehicleNumber.ToLower())
            //        {
            //            vehicleList[i] = null;
            //        }
            //        else "Please choose a correct vehicle registraition number to remove".PrintLine();
            //    }
            //}

            if (input <= Counter() && input >= 0)
            {

                vehicleList[input - 1] = null;


                int start = 0;
                int end = vehicleList.Length - 1;

                for (int i = 0; i < vehicleList.Length; i++)
                {
                    if (vehicleList[i] != null)
                    {
                        tmp[start] = vehicleList[i];
                        start++;
                    }
                    else
                    {
                        tmp[end] = vehicleList[i];
                        end--;
                    }
                }

                for (int i = 0; i < vehicleList.Length; i++)
                {
                    vehicleList[i] = tmp[i];

                }
                return false;
            }

            return true;



        }

        public int Counter()
        {
            counter = 0;
            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] != null)
                {
                    counter++;
                }
            }
            return counter;
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
                 if(item != null) yield return item;                
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
