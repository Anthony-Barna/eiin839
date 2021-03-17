using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsLibrairyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MathService.MathsOperationsClient service = new MathService.MathsOperationsClient();
            Console.WriteLine(service.Multiply(4, 5));
            Console.ReadLine();
        }
    }
}
