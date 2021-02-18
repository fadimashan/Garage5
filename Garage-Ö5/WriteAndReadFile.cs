using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Garage_Ö5
{
    public class WriteAndReadFile
    {
        string path = $"{Environment.CurrentDirectory}/Sample.txt";
        Oprations op;

        public WriteAndReadFile(int capacity)
        {
            op = new Oprations(capacity);
            var file = Path.Combine(path);
            if (!File.Exists(path))
            {
                FileStream fs = File.Create(file);
                fs.Close();
            }
        }

        public void WriteFile()
        {
            var vehicle = op.garageHandler.currentGarage.ToList();
            List<string> output = new List<string>();

            vehicle.Where(a => a is Car)
               .ToList()
               .ForEach(car =>
               output.Add($"{car.GetType().Name},{car.RegistreringNum},{car.Color},{car.WheelsNum},{(car as Car).Cylinder}"));

            vehicle.Where(a => a is Boat)
                .ToList()
                .ForEach(boat =>
               output.Add($"{boat.GetType().Name},{boat.RegistreringNum},{boat.Color},{boat.WheelsNum},{(boat as Boat).Lenght}"));

            vehicle.Where(a => a is Airplane)
               .ToList()
               .ForEach(airplane =>
               output.Add($"{airplane.GetType().Name},{airplane.RegistreringNum},{airplane.Color},{airplane.WheelsNum},{(airplane as Airplane).EnginesNum}"));

            vehicle.Where(a => a is Bus)
               .ToList()
               .ForEach(bus =>
               output.Add($"{bus.GetType().Name},{bus.RegistreringNum},{bus.Color},{bus.WheelsNum},{(bus as Bus).SeatsNum}"));

            vehicle.Where(a => a is Motorcycle)
               .ToList()
               .ForEach(motor =>
               output.Add($"{motor.GetType().Name},{motor.RegistreringNum},{motor.Color},{motor.WheelsNum},{(motor as Motorcycle).Fueltype}"));

            File.WriteAllLines(path, output);
            "All data saved!\n".PrintLine();
            "************************************************************************\n\n".PrintLine();
        }

        public List<string> ReadFile()
        {

            List<string> lines = File.ReadAllLines(path).ToList();
            return lines;
        }
    }
}
