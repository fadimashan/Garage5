using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Ö5
{
    public interface IGarageHandler
    {
        public Garage<Vehicle> newGarage { get; set; }


        public void Add(Vehicle item);

        public Garage<Vehicle> Print();
        
    }
     abstract class GarageHandler: IGarageHandler
    {
        Garage<Vehicle> garage = new Garage<Vehicle>();

        public GarageHandler()
        {
            
           
        }

        Garage<Vehicle> IGarageHandler.newGarage { get => this.garage; set =>  new Garage<Vehicle>(); }

        public void Add(Vehicle item)
        {
            garage.Add(item);
        }


        public Garage<Vehicle> Print()
        {
            return garage;
        }
    }
}
