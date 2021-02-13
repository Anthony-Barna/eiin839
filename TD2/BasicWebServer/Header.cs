using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;

namespace BasicWebServer
{
    class Header
    {
        private HttpListenerRequest request;

        public Header(HttpListenerRequest httpListenerRequest)
        {
            this.request = httpListenerRequest;
        }

        public NameValueCollection getHeaders()
        {
            return request.Headers;
        }

        // Creating header category
        public NameValueCollection getAcceptHeaders()
        {
            NameValueCollection headers = getHeaders();
            NameValueCollection res = new NameValueCollection();

            int i = 0;
            foreach (string key in headers.AllKeys)
            {
                if(
                    key.Equals(translateToHttpRequestHeaderName(HttpRequestHeader.Accept)) || 
                    key.Equals(translateToHttpRequestHeaderName(HttpRequestHeader.AcceptCharset)) ||
                    key.Equals(translateToHttpRequestHeaderName(HttpRequestHeader.AcceptEncoding)) ||
                    key.Equals(translateToHttpRequestHeaderName(HttpRequestHeader.AcceptLanguage)))
                {
                    res.Add(key, headers.Get(key));
                    headers.Remove(key);
                }
                i++;
            }
            
            return res;
        }

        public NameValueCollection getConnexionHeaders()
        {
            NameValueCollection headers = getHeaders();
            NameValueCollection res = new NameValueCollection();

            int i = 0;
            foreach (string key in headers.AllKeys)
            {
                if (
                    key.Equals(translateToHttpRequestHeaderName(HttpRequestHeader.Host)) ||
                    key.Equals(translateToHttpRequestHeaderName(HttpRequestHeader.Referer)) ||
                    key.Equals(translateToHttpRequestHeaderName(HttpRequestHeader.Connection)))
                {
                    res.Add(key, headers.Get(key));
                    headers.Remove(key);
                }
                i++;
            }

            return res;
        }

        public  void printHeaders(String collectionName, NameValueCollection headers)
        {
            Console.WriteLine(collectionName);
            // Get each header and display each value.
            foreach (string key in headers.AllKeys)
            {
                string[] values = headers.GetValues(key);
                
                Console.WriteLine("   {0}:", key);
                foreach (string value in values)
                {
                    Console.WriteLine("      {0}", value);
                }
            }
        }

        public String translateToHttpRequestHeaderName(HttpRequestHeader header)
        {
            if (header.Equals(HttpRequestHeader.AcceptCharset)) return "Accept-Charset";
            else if (header.Equals(HttpRequestHeader.AcceptEncoding)) return "Accept-Encoding";
            else if (header.Equals(HttpRequestHeader.AcceptLanguage)) return "Accept-Language";
            else return header.ToString();
        }
    }
}
