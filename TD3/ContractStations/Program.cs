using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractStations
{
    class Program
    {
        static void Main(string[] args)
        {
            StationsRequester.Main("https://api.jcdecaux.com/vls/v3/stations?contract=" + args[0] + "&apiKey=3c5ed057252a1b0c14e48e7fe65e6c1dcd2140c3").Wait();
            Console.ReadLine();
        }
    }
}
