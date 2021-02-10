using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Ö5
{
    class Setup
    {
        public Setup()
        {
            
            "Enter the capacity for the Garage".PrintLine();
            var capacity = Console.ReadLine();
            int capacityNum = 0;
            capacityNum = capacity.ParesToInt(capacityNum);
            var op = new Oprations(capacityNum);
           // int counter = op.Conter();
            while (true)
            {
                // Console.Clear();
                ("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                 + "\n1. Add a new Vehicale"
                 + "\n2. Remove a Vehicale"
                 + "\n3. Print a list of the vehivls in the garage"
                 + "\n4. Search on vehicle via the registration number"
                 + "\n5. Search on vehicles via the Color, wheels number or type"
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
                        op.PrintVehicleList();
                        $"number of vehicles is: {op.Conter()}\n\n".PrintLine();
                        break;
                    case '4':
                        op.SearchOnVehicle();
                        break; 
                    case '5':
                        // Search on vehicles via the Color, wheels number or type

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
