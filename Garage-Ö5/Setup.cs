using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Garage_Ö5
{
    public class Setup
    {

        private IConfiguration config;

        public Setup(IConfiguration config)
        {
            this.config = config;
        }
        public void Run()
        {

            var capacityNum = config.GetGarageSetting("capacity");

            var op = new Oprations(capacityNum);
            WriteAndReadFile wRFile = new WriteAndReadFile(capacityNum);

            while (true)
            {
                ("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                 + "\n1. Add a new Vehicale"
                 + "\n2. Remove a Vehicale"
                 + "\n3. Print a list of the vehivls in the garage"
                 + "\n4. Print a number of the vehivls in the garage"
                 + "\n5. Search on vehicle via the registration number"
                 + "\n6. Search on vehicles via the Color, wheels number or type"
                 + "\n7. Save all Data to file"
                 + "\n8. Read all the saved Data"
                 + "\n0. Exit the application").PrintLine();

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
                        Console.Clear();
                        op.AddVehicleOption();

                        break;
                    case '2':
                        Console.Clear();
                        op.ListForRemoveVehicale();

                        op.RemoveItem();
                        break;
                    case '3':
                        Console.Clear();
                        "\n*************List of Vehicles************\n".PrintLine();
                        op.PrintVehicleList();
                        $"number of vehicles is: {op.garageHandler.garage.Counter()}\n\n".PrintLine();
                        break;
                    case '4':
                        Console.Clear();
                        op.PrintNumOfVehicle();
                        $"number of vehicles is: {op.garageHandler.garage.Counter()}\n\n".PrintLine();
                        break;
                    case '5':
                        op.SearchOnVehicle();
                        break;
                    case '6':
                        op.SerchViaProperties();
                        break;
                    case '7':
                        wRFile.WriteFile();
                        break;
                    case '8':
                        op.ReadFromFile();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        ("Please enter some valid input (0, 1, 2, 3, 4)").PrintLine();
                        break;
                }
            }
        }

        private void Initialize()
        {
            var capacity = config.GetGarageSetting("capacity");

        }
    }
}
