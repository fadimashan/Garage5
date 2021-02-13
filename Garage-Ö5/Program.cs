using Microsoft.Extensions.Configuration;
using System;

namespace Garage_Ö5
{
    class Program
    {
        static void Main(string[] args)
        {
            //var setup = new Setup();
            //setup.Run();

            var startup = new StartUp();
            startup.SetUp();

        }
    }
}
