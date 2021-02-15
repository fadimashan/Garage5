using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage_Ö5
{
    public class Oprations
    {
        public GarageHandler garageHandler;
        public int counter;
        public int Capacity { get; set; }
        public Oprations(int capacity)
        {
            garageHandler = new GarageHandler(capacity);
            garageHandler.AddVehicale(new Car("car123", "Red", 4, 12));
            counter = garageHandler.currentGarage.Counter();
            Capacity = capacity;
            
        }

   

        // features 
        internal void SearchOnVehicle()
        {
            Console.Clear();
            var vehicleList = garageHandler.currentGarage.ToArray();
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
            var vehList = garageHandler.currentGarage.ToArray();
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

            var searchList = garageHandler.currentGarage.SearchOnVehicle(vehicleName, vehicleColor, vehicleWeelsNumber);

            searchList.Where(a => a != null)
                .ToList()
                .ForEach(a =>
                $"This vehicle is a {a.WheelsNum} wheels {a.GetType().Name}, Color: {a.Color}, Registration#: {a.RegistreringNum}".PrintLine());

            "\n\n*******************************************\n\n".PrintLine();
        }
        public void RemoveItem()
        {
            if (garageHandler.currentGarage.Counter() <= 0)
            {
                "There is no vehicle in the garage!\n\n".PrintLine();
                return;
            }
            else
            {
                var vehicleList = garageHandler.currentGarage.ToArray();
                "Enter a vehicle nuber to remove it".PrintLine();
                bool removeCon = false;
                do
                {
                    string vehicleNumber = Console.ReadLine();
                    int output = 0;
                    output = vehicleNumber.ParesToInt(output);
                    removeCon = garageHandler.currentGarage.RemoveItem(output);
                    if (!removeCon)
                    {
                        "Please choose a correct vehicle registraition number to remove".PrintLine();
                    }
                    else
                    {
                        "Vehicle was removed seccussfuly!\n\n".PrintLine();
                    }
                }
                while (!removeCon);
            }
        }


        // UI functions
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
        internal void ListForRemoveVehicale()
        {
            var vehicleList = garageHandler.currentGarage.ToArray();
            for (int i = 0; i < vehicleList.Length; i++)
            {
                if (vehicleList[i] != null)
                {
                    $"{i + 1}. This vehicle is {vehicleList[i].GetType().Name}, the registration#: {vehicleList[i].RegistreringNum}".PrintLine();
                }
            }
        }
        public void PrintVehicleList()
        {
            var arr = garageHandler.currentGarage.ToArray();
            arr.Where(a => a is Car)
                .ToList()
                .ForEach(car =>
                $"This vehicle is a {car.WheelsNum} wheels {car.GetType().Name}, Color: {car.Color}, Registration#: {car.RegistreringNum} and {(car as Car).Cylinder} Cylinder".PrintLine());

            arr.Where(a => a is Boat)
               .ToList()
               .ForEach(boat =>
               $"This vehicle is a {boat.WheelsNum} wheels {boat.GetType().Name}, Color: {boat.Color}, Registration#: {boat.RegistreringNum} and {(boat as Boat).Lenght} lenght".PrintLine());

            arr.Where(a => a is Airplane)
               .ToList()
               .ForEach(airplane =>
               $"This vehicle is a {airplane.WheelsNum} wheels {airplane.GetType().Name}, Color: {airplane.Color}, Registration#: {airplane.RegistreringNum} with {(airplane as Airplane).EnginesNum} Engines".PrintLine());

            arr.Where(a => a is Bus)
               .ToList()
               .ForEach(bus =>
               $"This vehicle is a {bus.WheelsNum} wheels {bus.GetType().Name}, Color: {bus.Color}, Registration#: {bus.RegistreringNum} and Seats number: {(bus as Bus).SeatsNum}".PrintLine());

            arr.Where(a => a is Motorcycle)
               .ToList()
               .ForEach(motor =>
               $"This vehicle is a {motor.WheelsNum} wheels {motor.GetType().Name}, Color: {motor.Color}, Registration#: {motor.RegistreringNum} and FuelType: {(motor as Motorcycle).Fueltype} ".PrintLine());

        }
        public void PrintNumOfVehicle()
        {
            var arr = garageHandler.currentGarage.ToArray();
            if (arr.Length != 0)
            {
                var carnum = arr.Where(a => a is Car).Count();
                var boatnum = arr.Where(a => a is Boat).Count();
                var airplanenum = arr.Where(a => a is Airplane).Count();
                var busnum = arr.Where(a => a is Bus).Count();
                var motornum = arr.Where(a => a is Motorcycle).Count();

                Console.Clear();
                "\n********Number the Vehicles in the Garage******\n".PrintLine();
                string allVehicls = "";
                if (carnum > 0) allVehicls = allVehicls + $"-({carnum}#) Car\n";
                if (boatnum > 0) allVehicls = allVehicls + $"-({boatnum}#) Boat\n";
                if (airplanenum > 0) allVehicls = allVehicls + $"-({airplanenum}#) Airplane\n";
                if (busnum > 0) allVehicls = allVehicls + $"-({busnum}#) Bus\n";
                if (busnum > 0) allVehicls = allVehicls + $"-({busnum}#) Motorcycle\n";

                allVehicls.PrintLine();
            }
            else { "Garage is empty!".PrintLine(); }
        }
        public void ReadFromFile()
        {
            WriteAndReadFile wdf = new WriteAndReadFile(Capacity);
            var lines = wdf.ReadFile();
            var vehList = garageHandler.currentGarage.vehLenght;

            if (vehList < lines.Capacity) 
            { "You will not be able to restore all the data because the new capacity less than the data size!\n\n".PrintLine(); }
            
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                {
                    if (entries[0].ToLower() == "car")
                    {
                        Car car = new Car(entries[1], entries[2], int.Parse(entries[3]), int.Parse(entries[4]));

                        if (!RegistrationIsUnique(car))
                        {
                            garageHandler.AddVehicale(car);
                        }
                    }

                    if (entries[0].ToLower() == "boat")
                    {
                        Boat boat = new Boat(entries[1], entries[2], int.Parse(entries[3]), double.Parse(entries[4]));
                        garageHandler.AddVehicale(boat);
                    }

                    if (entries[0].ToLower() == "airplane")
                    {
                        Airplane air = new Airplane(entries[1], entries[2], int.Parse(entries[3]), int.Parse(entries[4]));

                        if (!RegistrationIsUnique(air))
                        {
                            garageHandler.AddVehicale(air);
                        }
                    }

                    if (entries[0].ToLower() == "bus")
                    {
                        Bus bus = new Bus(entries[1], entries[2], int.Parse(entries[3]), int.Parse(entries[4]));

                        if (!RegistrationIsUnique(bus))
                        {
                            garageHandler.AddVehicale(bus);
                        }
                    }

                    if (entries[0].ToLower() == "motorcycle")
                    {
                        Motorcycle motor = new Motorcycle(entries[1], entries[2], int.Parse(entries[3]), entries[4]);

                        if (!RegistrationIsUnique(motor))
                        {
                            garageHandler.AddVehicale(motor);
                        }
                    }
                }
            }
            { "Restoring the Date done successfully\n\n".PrintLine(); }

        }


        //verification if registration number is unique 
        public bool RegistrationIsUnique(Vehicle ve)
        {
            bool isUnique = false;
            var arrList = garageHandler.currentGarage.ToArray();
            for (int i = 0; i < arrList.Length; i++)
            {
                if (arrList[i] != null)
                {
                    isUnique = false;
                    if (arrList[i].RegistreringNum.ToLower() == ve.RegistreringNum.ToLower())
                    {
                        isUnique = true;
                        return true;
                    }
                }

            }
            return isUnique;
        }



        /* Other type Vehicle method
         */
        public void AddCar()
        {
            var vehicle = AddNewVehicle();
            ("enter cylender").PrintLine();
            var input = Console.ReadLine();
            int output = 0;
            output = input.ParesToInt(output);
            var car = new Car(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, output);
            garageHandler.AddVehicale(car);
            List<string> cars = new List<string> { car.RegistreringNum, car.WheelsNum.ToString(), car.Color, car.Cylinder.ToString() };
        }
        public void AddBoat()
        {
            var vehicle = AddNewVehicle();
            ("enter lenght").PrintLine();
            var input = Console.ReadLine();
            int output = 0;
            output = input.ParesToInt(output);
            var boat = new Boat(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, output);
            garageHandler.AddVehicale(boat);
        }
        public void AddAirplane()
        {
            var vehicle = AddNewVehicle();
            ("enter engin number").PrintLine();
            var input = Console.ReadLine();
            int output = 0;
            output = input.ParesToInt(output);
            var airplane = new Airplane(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, output);
            garageHandler.AddVehicale(airplane);
        }
        public void AddBus()
        {
            var vehicle = AddNewVehicle();
            ("enter sets number").PrintLine();
            var input = Console.ReadLine();
            int output = 0;
            output = input.ParesToInt(output);
            var bus = new Bus(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, output);
            garageHandler.AddVehicale(bus);
        }
        public void AddMotorcycle()
        {
            var vehicle = AddNewVehicle();
            ("enter fueltype").PrintLine();
            var input = Console.ReadLine();
            var motorcycle = new Motorcycle(vehicle.RegistreringNum, vehicle.Color, vehicle.WheelsNum, input);
            garageHandler.AddVehicale(motorcycle);
        }



        /* General Vehicle method
         */
        public Vehicle AddNewVehicle()
        {
            string register = RegistrationNumber();
            string color = Color();
            int wheel = WheelsNum();
            return new Vehicle(register, color, wheel);

        }

        public string RegistrationNumber()
        {
            string registerInput;
            bool isUnique = true;
            do
            {
                isUnique = true;
                var arrList = garageHandler.garage.ToArray();
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
