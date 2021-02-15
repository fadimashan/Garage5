﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Garage_Ö5
{
    public interface IGarageHandler :  IEnumerable
    {
        public void AddVehicale<T>(T item);
        public Garage<Vehicle> Print();
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

        public void ChoseGarage()
        {
            Console.Clear();
            "This is the accesit Garages.".PrintLine();
            for (int i = 0; i < listOfGarage.Count; i++)
            {
                $"{i + 1}. {listOfGarage[i].Name}".PrintLine();
            }

            "Chose a Garage number to use.".PrintLine();
            var input = Console.ReadLine();
            int n = 0;
            n = input.ParesToInt(n);
            currentGarage = listOfGarage[n - 1];
        }
   
        public void AddVehicale<T>(T item)
        {
            currentGarage.Add(item as Vehicle);
        }

        public Garage<Vehicle> Print()
        {
            return garage;
        }

        public void CreateNewGarage(int capacity, string garageName )
        {

            Garage<Vehicle> newGarage = new Garage<Vehicle>(capacity, garageName);
            listOfGarage.Add(newGarage);
            currentGarage = newGarage;

        }

        IEnumerator IEnumerable.GetEnumerator() => garage.GetEnumerator();

    }
}
