using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Garage_Ö5
{
    class Setup
    {
        WriteAndReadFile wRFile;
   
        public void Run()
        {
           // WriteAndReadFile wRFile = new WriteAndReadFile();
         
            "Enter the capacity for the Garage".PrintLine();
            var capacity = Console.ReadLine();
            int capacityNum = 0;
            capacityNum = capacity.ParesToInt(capacityNum);
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
                        //  op.RemoveItem();
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
                       // op.PrintVehicleList(true);
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
    }
}
