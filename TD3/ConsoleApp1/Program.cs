using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpGetRequester.Main("https://api.jcdecaux.com/vls/v3/contracts?apiKey=3c5ed057252a1b0c14e48e7fe65e6c1dcd2140c3").Wait();
            Console.ReadLine();
        }
    }
}
