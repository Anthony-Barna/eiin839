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
            /*MathService.MathsOperationsClient service = new MathService.MathsOperationsClient();
            Console.WriteLine(service.Multiply(4, 5));
            ServiceReference1.Service1Client service2 = new ServiceReference1.Service1Client("SoapEndPnt1");
            Console.WriteLine(service2.GetData2(5));
            ServiceReference1.Service1Client service3 = new ServiceReference1.Service1Client("SoapEndPnt2");
            Console.WriteLine(service2.GetData1(6));
            */
            ServiceReference2.Service1Client service2 = new ServiceReference2.Service1Client("SoapEndPnt11");
            Console.WriteLine(service2.GetData2(5));
            ServiceReference2.Service1Client service3 = new ServiceReference2.Service1Client("SoapEndPnt21");
            Console.WriteLine(service2.GetData1(6));
            Console.ReadLine();
        }
    }
}
