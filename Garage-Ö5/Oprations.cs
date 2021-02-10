using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage_Ö5
{
    public class Oprations
    {
        public GarageHandler garageHandler;
        public int counter = 0;
        public Oprations(int capacity)
        {
            garageHandler = new GarageHandler(capacity);

            garageHandler.garage.vehicleList[0] = new Car("car123", "Red", 4, 12);
            garageHandler.garage.vehicleList[1] = new Airplane("air123", "Red", 6, 2);
            garageHandler.garage.vehicleList[2] = new Car("car125", "yellow", 8, 16);

        }

        public void AddCar()
        {
            var vehicle = AddNewVehicle();
            ("enter cylender").PrintLine();
            var input = Console.ReadLine();
            int output = 0;
            output = input.ParesToInt(output);
            var car = new Car(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, output);
            garageHandler.Add(car);
        }

        public void AddBoat()
        {
            var vehicle = AddNewVehicle();
            ("enter lenght").PrintLine();
            var input = Console.ReadLine();
            int output = 0;
            output = input.ParesToInt(output);
            var boat = new Boat(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, output);
            garageHandler.Add(boat);
        }

        public void AddAirplane()
        {
            var vehicle = AddNewVehicle();
            ("enter engin number").PrintLine();
            var input = Console.ReadLine();
            int output = 0;
            output = input.ParesToInt(output);
            var airplane = new Airplane(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, output);
            garageHandler.Add(airplane);
        }

        public void AddBus()
        {
            var vehicle = AddNewVehicle();
            ("enter sets number").PrintLine();
            var input = Console.ReadLine();
            int output = 0;
            output = input.ParesToInt(output);
            var bus = new Bus(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, output);
            garageHandler.Add(bus);
        }

        internal void SearchOnVehicle()
        {
            Console.Clear();
            var vehicleList = garageHandler.garage.vehicleList;
            "Enter the vehicale registration number to see the details".PrintLine();
            string regiNumber = Console.ReadLine();
            bool access = false;
            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] != null && vehicleList[i].RegistreringNum.ToLower() == regiNumber.ToLower())
                {
                    if (vehicleList[i] is Car)
                    {
                        var car = vehicleList[i] as Car;
                        ($" This Vehicle is a {car.WheelsNum} wheels Car, The registration#: {car.RegistreringNum}, Color: {car.Color} and it's: {car.Cylinder} Cylinder \n\n").PrintLine();
                        access = true;
                    }

                    if (vehicleList[i] is Boat)
                    {
                        var boat = vehicleList[i] as Boat;
                        ($" This Vehicle is a {boat.WheelsNum} wheels Boat, The registration#: {boat.RegistreringNum}, Color: {boat.Color} and it's: {boat.Lenght} Lenght \n\n").PrintLine();
                        access = true;
                    }

                    if (vehicleList[i] is Airplane)
                    {
                        var airplane = vehicleList[i] as Airplane;
                        ($" This Vehicle is a {airplane.WheelsNum} wheels Airplane, The registration#: {airplane.RegistreringNum}, Color: {airplane.Color}, with: {airplane.EnginesNum} Engins \n\n").PrintLine();
                        access = true;
                    }

                    if (vehicleList[i] is Bus)
                    {
                        var bus = vehicleList[i] as Bus;
                        ($" This Vehicle is a {bus.WheelsNum} wheels Bus, The registration#: {bus.RegistreringNum}, Color: {bus.Color}, with: {bus.SeatsNum} sets \n\n").PrintLine();
                        access = true;
                    }

                    if (vehicleList[i] is Motorcycle)
                    {
                        var motorcycle = vehicleList[i] as Motorcycle;
                        ($" This Vehicle is a {motorcycle.WheelsNum} wheels Motorcycle, The registration#: {motorcycle.RegistreringNum}, Color: {motorcycle.Color} and Fueltype is: {motorcycle.Fueltype}\n\n").PrintLine();
                        access = true;
                    }
                }
            }
            if (!access) "This registrtion# not access!".PrintLine();
        }

        public void SerchViaProperties()
        {
            string vehicleName = " ";
            string vehicleColor = " ";
            int vehicleWeelsNumber = -1;
            var vehList = garageHandler.garage.vehicleList;
            "Do you want to serch via vehicle type? (prees (1) if Yes, (0) for No".PrintLine();
            bool vType = true;
            do
            {
                Char veType = Console.ReadLine()[0];
                switch (veType)
                {
                    case '1':
                        "Write type of vehicle.".PrintLine();
                        string vehicleType = Console.ReadLine();
                        if (vehicleType.ToLower() == "car" || vehicleType.ToLower() == "airplane" || vehicleType.ToLower() == "boat" || vehicleType.ToLower() == "bus" || vehicleType.ToLower() == "motorcycle")
                        {
                            vehicleName = vehicleType;
                            vehicleName = vehicleName[0].ToString().ToUpper() + vehicleName.Substring(1);
                        }
                        vType = false;
                        break;
                    case '0':
                        vType = false;
                        break;
                    default:
                        ("Please enter some valid input (0, 1)").PrintLine();
                        break;
                }
            } while (vType);
            "Do you want to serch via vehicle color? (prees (1) if Yes, (0) for No".PrintLine();
            bool vColor = true;
            do
            {
                Char veColor = Console.ReadLine()[0];
                switch (veColor)
                {
                    case '1':
                        "Write Color of vehicle.".PrintLine();
                        vehicleColor = Console.ReadLine();
                        vColor = false;
                        break;
                    case '0':
                        vColor = false;
                        break;
                    default:
                        ("Please enter some valid input (0, 1)").PrintLine();
                        break;
                }
            } while (vColor);
            "Do you want to serch via vehicle wheels number? (prees (1) if Yes, (0) for No".PrintLine();
            bool vWheel = true;
            do
            {
                Char veWheels = Console.ReadLine()[0];
                switch (veWheels)
                {
                    case '1':
                        "Write number of Wheels of vehicle.".PrintLine();
                        var vehicleWeel = Console.ReadLine();
                        vehicleWeelsNumber = vehicleWeel.ParesToInt(vehicleWeelsNumber);
                        vWheel = false;
                        break;
                    case '0':
                        vWheel = false;
                        break;
                    default:
                        ("Please enter some valid input (0, 1)").PrintLine();
                        break;
                }
            } while (vWheel);

            Console.Clear();
            "\n*************Search on Vehicles************\n".PrintLine();

            vehList.Where(ve => ve != null)
                                .Where(ve => (!string.IsNullOrWhiteSpace(vehicleName)) && ve.GetType().Name.ToLower() == vehicleName.ToLower()
                                || (!string.IsNullOrWhiteSpace(vehicleColor)) && ve.Color.ToLower() == vehicleColor.ToLower()
                                || vehicleWeelsNumber != -1 && ve.WheelsNum == vehicleWeelsNumber)
                                .ToList().ForEach(ve =>
                                $"This vehicle is a {ve.WheelsNum} wheels {ve.GetType().Name}, The Color is: {ve.Color}".PrintLine());

            "\n\n*******************************************\n\n".PrintLine();
        }

        public void RemoveItem()
        {
            var vehicleList = garageHandler.garage.vehicleList;
            "Enter a vehicle nuber to remove it".PrintLine();
            bool removeCon = true;
            do
            {
                string vehicleNumber = Console.ReadLine();
                int output = 0;
                output = vehicleNumber.ParesToInt(output);
                var con = Counter();
                if (output <= con && output > 0)
                {
                    vehicleList[output - 1] = null;
                    removeCon = false;
                }
                else "Please choose a correct vehicle number to remove".PrintLine();
            }
            while (removeCon);
        }

        internal void ListForRemoveVehicale()
        {
            var vehicleList = garageHandler.garage.vehicleList;
            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] != null)
                {
                    $"{i + 1}. This vehicle is {vehicleList[i].GetType().Name}, the registration#: {vehicleList[i].RegistreringNum}".PrintLine();
                }
            }
        }

        public void AddMotorcycle()
        {
            var vehicle = AddNewVehicle();
            ("enter fueltype").PrintLine();
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

        public int Counter()
        {
            counter = 0;
            var le = garageHandler.garage.vehicleList;
            for (int i = 0; i < le.Length; i++)
            {
                if (le[i] != null)
                {
                    counter++;
                }
            }
            return counter;
        }

        public void PrintVehicleList(bool printNumbers)
        {
            int cars = 0;
            int airplanes = 0;
            int boats = 0;
            int buss = 0;
            int motors = 0;
            var arr = garageHandler.garage.vehicleList;
            foreach (var ve in arr)
            {
                if (ve is Car)
                {
                    var car = ve as Car;
                    cars++;
                    $"This vehicle is a {car.WheelsNum} wheels {ve.GetType().Name}, Color: {car.Color}, Registration#: {car.RegistreringNum} and {car.Cylinder}".PrintLine();
                }

                if (ve is Boat)
                {
                    var boat = ve as Boat;
                    boats++;
                    $"This vehicle is a {boat.WheelsNum} wheels {ve.GetType().Name}, Color: {boat.Color}, Registration#: {boat.RegistreringNum}, {boat.Lenght} lenght".PrintLine();

                }

                if (ve is Airplane)
                {
                    var airplane = ve as Airplane;
                    airplanes++;
                    $"This vehicle is a {airplane.WheelsNum} wheels {ve.GetType().Name}, Color: {airplane.Color}, Registration#: {airplane.RegistreringNum} with {airplane.EnginesNum} engines".PrintLine();

                }

                if (ve is Bus)
                {
                    var bus = ve as Bus;
                    buss++;
                    $"This vehicle is a {bus.WheelsNum} wheels {ve.GetType().Name}, Color: {bus.Color}, Registration#: {bus.RegistreringNum} and have {bus.SeatsNum} sets ".PrintLine();

                }

                if (ve is Motorcycle)
                {
                    var motorcycle = ve as Motorcycle;
                    motors++;
                    $"This vehicle is a {motorcycle.WheelsNum} wheels {ve.GetType().Name}, Color: {motorcycle.Color}, Registration#: {motorcycle.RegistreringNum} and {motorcycle.Fueltype}".PrintLine();

                }
            }

            if (printNumbers)
            {
                Console.Clear();
                "\n********Number the Vehicles in the Garage******\n".PrintLine();
                string allVehicls = "";
                if (cars > 0) allVehicls = allVehicls + $"-({cars}#) Car\n";
                if (boats > 0) allVehicls = allVehicls + $"-({boats}#) Boat\n";
                if (airplanes > 0) allVehicls = allVehicls + $"-({airplanes}#) Airplane\n";
                if (buss > 0) allVehicls = allVehicls + $"-({buss}#) Bus\n";
                if (motors > 0) allVehicls = allVehicls + $"-({motors}#) Motorcycle\n";

                allVehicls.PrintLine();
            }
        }

        public void AddVehicleOption()
        {
            bool goToMainmenu = false;
            while (!goToMainmenu)
            {
                ("\nWhat vehicle you want to add:"
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
                        if (garageHandler.garage.CheckIfThereIsNull())
                        {
                            Console.Clear();
                            "\n*************Add new Car************\n".PrintLine();
                            AddCar();
                            "Successed! You Add a new Car to the Garage\n\n".PrintLine();
                            goToMainmenu = true;
                        }
                        else { "Garage is full!\n\n".PrintLine(); goToMainmenu = true; }
                        break;
                    case '2':
                        if (garageHandler.garage.CheckIfThereIsNull())
                        {
                            Console.Clear();
                            "\n*************Add new Airplane************\n".PrintLine();
                            AddAirplane();
                            "Successed! You Add a new Airplane to the Garage\n\n".PrintLine();

                            goToMainmenu = true;
                        }
                        else { "Garage is full!\n\n".PrintLine(); goToMainmenu = true; }
                        break;
                    case '3':
                        if (garageHandler.garage.CheckIfThereIsNull())
                        {
                            Console.Clear();
                            "\n*************Add new Boat************\n".PrintLine();
                            AddBoat();
                            "Successed! You Add a new Boat to the Garage\n\n".PrintLine();

                            goToMainmenu = true;
                        }
                        else { "Garage is full!\n\n".PrintLine(); goToMainmenu = true; }
                        break;
                    case '4':
                        if (garageHandler.garage.CheckIfThereIsNull())
                        {
                            Console.Clear();
                            "\n*************Add new Bus************\n".PrintLine();
                            AddBus();
                            "Successed! You Add a new Bus to the Garage\n\n".PrintLine();

                            goToMainmenu = true;
                        }
                        else { "Garage is full!\n\n".PrintLine(); goToMainmenu = true; }
                        break;
                    case '5':
                        if (garageHandler.garage.CheckIfThereIsNull())
                        {
                            Console.Clear();
                            "\n*************Add new Motorcycle************\n".PrintLine();
                            AddMotorcycle();
                            "Successed! You Add a new Motorcycle to the Garage\n\n".PrintLine();

                            goToMainmenu = true;
                        }
                        else { "Garage is full!\n\n".PrintLine(); goToMainmenu = true; }
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
            string registerInput;
            bool isUnique = true;
            do
            {
                isUnique = true;
                var arrList = garageHandler.garage.vehicleList;
                "Add a registration number".PrintLine();
                registerInput = Console.ReadLine();
                for (int i = 0; i < arrList.Length; i++)
                {
                    if (arrList[i] != null)
                    {
                        isUnique = true;
                        if (arrList[i].RegistreringNum.ToLower() == registerInput.ToLower())
                        {
                            "Registration number should be unique!".PrintLine();
                            isUnique = false;

                        }
                    }

                }
            } while (!isUnique);

            return registerInput;
        }

        public string Color()
        {
            "Add a Color".PrintLine();
            var color = Console.ReadLine();
            return color;
        }

        public int WheelsNum()
        {
            "How many wheels".PrintLine();
            var wheelInput = Console.ReadLine();
            var wheelsNum = 0;
            wheelsNum = wheelInput.ParesToInt(wheelsNum);
            return wheelsNum;
        }

    }



}
