using System.Collections;
using System.Collections.Generic;

namespace Garage_Ö5
{
    public interface IGarageHandler :  IEnumerable
    {
        public void Add<T>(T item);
        public Garage<Vehicle> Print();
    }

    public class GarageHandler : IGarageHandler
    {

        public Garage<Vehicle> garage {get;}
        int capacity = 0;
        public GarageHandler(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
            this.capacity = capacity;
        }

        public Garage<Vehicle> newGarage => new Garage<Vehicle>(capacity);

        public void Add<T>(T item)
        {
            garage.Add(item as Vehicle);
        }

        public Garage<Vehicle> Print()
        {
            return garage;
        }

         IEnumerator IEnumerable.GetEnumerator() => garage.GetEnumerator();
       
    }
}
