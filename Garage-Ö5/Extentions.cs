using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Ö5
{
    public static class Extentions
    {
        static int result;
        public static void Print(this string str)
        {
            Console.Write(str);
        }
        public static void PrintLine(this string str)
        {
            Console.WriteLine(str);
        }

        public static bool CheckIfInt(this string str, int number)
        {

            if (int.TryParse(str, out number))
            {
                result = number;
            }

            return int.TryParse(str, out number);
        }


        public static int ParesToInt(this string str, int number)
        {
            try
            {
                if (CheckIfInt(str, number))
                {
                    number = result;
                    return number;
                }
            }
            catch (IndexOutOfRangeException) 
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }

            return -1;
        }


        public static void Print<T>(this IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Console.WriteLine(item.GetType().Name);
            }
        }

        //public static void PrintCar<Car>(this IEnumerable<Car> collection)
        //{
        //    foreach (Car item in collection)
        //    {
        //        if (item is Car) {
                   
        //            Console.WriteLine((item is Car).GetType().Name. );
        //        }
        //    }
        //}

    }
}
