using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Ö5
{
    class Setup
    {

        public Setup()
        {
            var op = new Oprations();
            while (true)
            {
               // Console.Clear();
                ("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                 + "\n1. Add a new Vehicale"
                 + "\n2. Remove a Vehicale"
                 + "\n3. Print a list of the vehivls in the garage"
                 + "\n4. Search on vehicle"
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
                        op.AddVehicleOption();
                        break;
                    case '2':

                        break;
                    case '3':
                        op.PrintVehicleList();
                        break;
                    case '4':

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
