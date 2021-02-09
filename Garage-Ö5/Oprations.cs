using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage_Ö5
{
    class Oprations
    {
        public GarageHandler garageHandler;
       // IGarageHandler IGarage { get; set;}

        public Oprations(int capacity)
        {
            garageHandler = new GarageHandler(capacity);
            
            //var newg = gh.newGarage;
            //var v1 = new Boat("Boat123", "white", 0, 34.3);
            //g.Add(v1);
            //garage.Add(v1);
            // igrage.Add(v1);
        }

        public void AddCar()
        {
            var vehicle = AddNewVehicle();
            Console.WriteLine("enter cylender");
            var input = Console.ReadLine();
            int output = 0;
            output = input.ParesToInt(output);
            var car = new Car(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, output);
            garageHandler.Add(car);
        }

        public void AddBoat()
        {
            var vehicle = AddNewVehicle();
            Console.WriteLine("enter lenght");
            var input = Console.ReadLine();
            int output = 0;
            output = input.ParesToInt(output);
            var boat = new Boat(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, output);
            garageHandler.Add(boat);
        }

        public void AddAirplane()
        {
            var vehicle = AddNewVehicle();
            Console.WriteLine("enter engin number");
            var input = Console.ReadLine();
            int output = 0;
            output = input.ParesToInt(output);
            var airplane = new Airplane(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, output);
            garageHandler.Add(airplane);
        }

        public void AddBus()
        {
            var vehicle = AddNewVehicle();
            Console.WriteLine("enter sets number");
            var input = Console.ReadLine();
            int output = 0;
            output = input.ParesToInt(output);
            var bus = new Bus(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, output);
            garageHandler.Add(bus);
        }

        public void AddMotorcycle()
        {
            var vehicle = AddNewVehicle();
            Console.WriteLine("enter fueltype");
            var input = Console.ReadLine();
            var motorcycle = new Motorcycle(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, input);
            garageHandler.Add(motorcycle);
        }

        public Vehicle AddNewVehicle()
        {
            string register = RegistrationNumber();
            string color = Color();
            int wheel = WheelsNum();
            return new Vehicle(register, color, wheel);
        }


        public void PrintVehicleList()
        {
            var list = garageHandler.Print();
            foreach (var ve in list)
            {
                if (ve is Car)
                {
                    var car = ve as Car;
                    Console.WriteLine($" This Vehicle is a {car.WheelsNum} wheels Car, The registration#: {car.RegistreringNum}, Color: {car.Color} and it's: {car.Cylinder} Cylinder ");
                }

                if (ve is Boat)
                {
                    var boat = ve as Boat;
                    Console.WriteLine($" This Vehicle is a {boat.WheelsNum} wheels Boat, The registration#: {boat.RegistreringNum}, Color: {boat.Color} and it's: {boat.Lenght} Lenght ");
                }

                if (ve is Airplane)
                {
                    var airplane = ve as Airplane;
                    Console.WriteLine($" This Vehicle is a {airplane.WheelsNum} wheels Airplane, The registration#: {airplane.RegistreringNum}, Color: {airplane.Color}, with: {airplane.EnginesNum} Engins");
                }

                if (ve is Bus)
                {
                    var bus = ve as Bus;
                    Console.WriteLine($" This Vehicle is a {bus.WheelsNum} wheels Bus, The registration#: {bus.RegistreringNum}, Color: {bus.Color}, with: {bus.SeatsNum} sets ");
                }

                if (ve is Motorcycle)
                {
                    var motorcycle = ve as Motorcycle;
                    Console.WriteLine($" This Vehicle is a {motorcycle.WheelsNum} wheels Motorcycle, The registration#: {motorcycle.RegistreringNum}, Color: {motorcycle.Color} and Fueltype is: {motorcycle.Fueltype}");
                }
            }
        }

        public void AddVehicleOption()
        {
            bool goToMainmenu = false;
            while (!goToMainmenu)
            {
                (  "\nWhat vehicle you want to add:"
                 + "\n1. Car"
                 + "\n2. Airplan"
                 + "\n3. Boat"
                 + "\n4. Bus"
                 + "\n5. Motorcycle"
                 + "\n0. Return to the main menu").PrintLine();
                char input = ' ';
                try
                {
                    input = Console.ReadLine()[0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    ("Please enter some input!").PrintLine();
                }
                switch (input)
                {
                    case '1':
                        AddCar();
                        goToMainmenu = true;
                        break;
                    case '2':
                        AddAirplane();
                        break;
                    case '3':
                        AddBoat();
                        break;
                    case '4':
                        AddBus();
                        break;
                    case '5':
                        AddMotorcycle();
                        break;
                    case '0':
                        goToMainmenu = true;
                        break;
                    default:
                        ("Please enter some valid input (0, 1, 2, 3, 4, 5)").PrintLine();
                        break;

                }
            }
        }


        public string RegistrationNumber()
        {
            Console.WriteLine("Add a registration number");
            var registerInput = Console.ReadLine();
            return registerInput;
        }

        public string Color()
        {
            Console.WriteLine("Add a Color");
            var color = Console.ReadLine();
            return color;
        }

        public int WheelsNum()
        {
            Console.WriteLine("How many wheels");
            var wheelInput = Console.ReadLine();
            var wheelsNum = 0;
            wheelsNum = wheelInput.ParesToInt(wheelsNum);
            return wheelsNum;
        }

    }



}
