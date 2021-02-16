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
        public Oprations op;
        private IConfiguration config;

        public Setup(IConfiguration config)
        {
            this.config = config;
        }
        public void Run()
        {

            var capacityNum = config.GetGarageSetting("capacity");

            op = new Oprations(capacityNum);
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
                 + "\n9. Go to Garages options"
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
                        $"number of vehicles is: {op.garageHandler.currentGarage.Counter()}\n\n".PrintLine();
                        break;
                    case '4':
                        Console.Clear();
                        op.PrintNumOfVehicle();
                        $"number of vehicles is: {op.garageHandler.currentGarage.Counter()}\n\n".PrintLine();
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
                    case '9':
                        GarageOptions();
                        break;

                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        ("Please enter some valid input (0, 1, 2, 3, 4)\n\n").PrintLine();
                        break;
                }
            }
        }

        public void GarageOptions()
        {
            bool garageOptions = true;
            while (garageOptions)
            {
                ("\n1. Add a new Garage"
                 + "\n2. Chose a Garage"
                 + "\n3. Delete a Garage"
                 + "\n4. Print List of Garages"
                 + "\n0. Go back to the main menu").PrintLine();

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
                        "Enter new name".PrintLine();
                        var name = Console.ReadLine();
                        var capacityNum = config.GetGarageSetting("capacity");
                        op.garageHandler.CreateNewGarage(capacityNum, name);
                        var garagesList = op.garageHandler.listOfGarage;
                        Console.Clear();
                        "This is a list of Garages you have:".PrintLine();
                        foreach (var garage in garagesList)
                        {
                            $"-{garage.Name}".PrintLine();
                        }
                        break;

                    case '2':
                        op.garageHandler.ChoseGarage();
                        break;
                    case '3':
                        op.garageHandler.DeleteGarage();
                        break;
                    case '4':
                        op.garageHandler.PrintGarageList();
                        break;
                    case '0':
                        garageOptions = false;
                        break;
                    default:
                        ("Please enter some valid input (0, 1, 2)").PrintLine();
                        break;
                }
            }
        }
    }
}
