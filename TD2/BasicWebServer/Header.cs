using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BasicWebServer
{
    class Header
    {
        private HttpListenerRequest request;

        public Header(HttpListenerRequest httpListenerRequest)
        {
            this.request = httpListenerRequest;
        }

        public System.Collections.Specialized.NameValueCollection getHeaders()
        {
            return request.Headers;
        }

        public  void printHeaders()
        {
            Console.WriteLine("Headers :");
            // Get each header and display each value.
            foreach (string key in getHeaders().AllKeys)
            {
                string[] values = getHeaders().GetValues(key);
                Console.WriteLine("   {0}:", key);
                foreach (string value in values)
                {
                    Console.WriteLine("      {0}", value);
                }
            }
            Console.WriteLine("\n");
        }
    }
}
