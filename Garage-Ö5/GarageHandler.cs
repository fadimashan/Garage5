using System;
using System.Collections;
using System.Collections.Generic;

namespace Garage_Ö5
{
    public interface IGarageHandler : IEnumerable
    {
        public void AddVehicale<T>(T item);

        public void CreateNewGarage(int capacity, string garageName);

        public void ChoseGarage();

        public void DeleteGarage();

        public void PrintGarageList();

    }

    public class GarageHandler : IGarageHandler
    {
        public List<Garage<Vehicle>> listOfGarage;
        public Garage<Vehicle> currentGarage;

        public Garage<Vehicle> garage { get; }
        int capacity = 0;
        public GarageHandler(int capacity)
        {
            listOfGarage = new List<Garage<Vehicle>>();
            this.capacity = capacity;
            CreateNewGarage(capacity, "garage");
        }

        public void AddVehicale<T>(T item)
        {
            currentGarage.Add(item as Vehicle);
        }
        public void CreateNewGarage(int capacity, string garageName)
        {

            Garage<Vehicle> newGarage = new Garage<Vehicle>(capacity, garageName);
            listOfGarage.Add(newGarage);
            currentGarage = newGarage;

        }
        public void ChoseGarage()
        {
            Console.Clear();
            "This is the accesit Garages.".PrintLine();
            PrintGarageList();
            "Chose a Garage number to use.".PrintLine();
            var input = Console.ReadLine();
            int n = 0;
            n = input.ParesToInt(n);
            currentGarage = listOfGarage[n - 1];
        }
        public void DeleteGarage()
        {
            Console.Clear();
            "This is the accesit Garages.".PrintLine();
            PrintGarageList();
            "Chose a Garage number to delete.".PrintLine();
            var input = Console.ReadLine();
            int n = 0;
            n = input.ParesToInt(n);
            listOfGarage.RemoveAt(n - 1);

        }
        public void PrintGarageList()
        {
            Console.Clear();
            "This is the accesit Garages.".PrintLine();
            for (int i = 0; i < listOfGarage.Count; i++)
            {
                $"{i + 1}. {listOfGarage[i].Name}".PrintLine();
            }

            ($"\n\nTotal number of the garages is: {listOfGarage.Count}"
             + $".\n***********************************************").PrintLine();

        }

        IEnumerator IEnumerable.GetEnumerator() => garage.GetEnumerator();

    }
}
