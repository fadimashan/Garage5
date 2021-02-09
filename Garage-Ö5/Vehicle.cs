using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Ö5
{

    public class Vehicle
    {

        public string RegistreringNum { get; set; }
        public string Color { get; set; }
        public int WheelsNum { get; set; }

        public Vehicle(string registreringNum, string color,int wheelsNum)
        {
            RegistreringNum = registreringNum;
            Color = color;
            WheelsNum = wheelsNum;
        }
      

    }

    class Airplane : Vehicle
    {
        public int EnginesNum { get; set; }

        public Airplane(string registreringNum, string color, int wheelsNum, int enginesNum) : base(registreringNum, color, wheelsNum)
        {
            EnginesNum = enginesNum;
        }

    }

    class Motorcycle : Vehicle
    {
        public string Fueltype { get; set; }

       public Motorcycle(string registreringNum, string color, int wheelsNum, string fueltype) : base(registreringNum, color, wheelsNum)
        {
            Fueltype = fueltype;
        }

    }

    public class Car : Vehicle
    {
        public int Cylinder { get; set; }

        public Car(string registreringNum, string color, int wheelsNum, int cylinder) : base(registreringNum, color, wheelsNum)
        {
            Cylinder = cylinder;
        }
    }

    class Bus : Vehicle
    {
        public int SeatsNum { get; set; }

        public Bus(string registreringNum, string color, int wheelsNum , int seatsNum) : base(registreringNum, color, wheelsNum)
        {
            SeatsNum = seatsNum;
        }
    }

    class Boat : Vehicle
    {
        public double Lenght { get; set; }

        public Boat(string registreringNum, string color, int wheelsNum, double lenght) : base(registreringNum, color, wheelsNum)
        {
            Lenght = lenght;
        }
    }


}
