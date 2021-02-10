﻿using BasicWebServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BasicServerHTTPlistener
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("A more recent Windows version is required to use the HttpListener class.");
                return;
            }


            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            if (args.Length != 0)
            {
                foreach (string s in args)
                {
                    listener.Prefixes.Add(s);
                    // don't forget to authorize access to the TCP/IP addresses localhost:xxxx and localhost:yyyy 
                    // with netsh http add urlacl url=http://localhost:xxxx/ user="Tout le monde"
                    // and netsh http add urlacl url=http://localhost:yyyy/ user="Tout le monde"
                    // user="Tout le monde" is language dependent, use user=Everyone in english 

                }
            }
            else
            {
                Console.WriteLine("Syntax error: the call must contain at least one web server url as argument");
            }
            listener.Start();
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }
                Console.WriteLine($"Received request for {request.Url}");
                Console.WriteLine(documentContents);

                // class for header utils fonctions
                Header headerUtils = new Header(request);
                // print request headers
                headerUtils.printHeaders();

                // class used to parse query
                UrlAnalyzer urlUtils = new UrlAnalyzer(request.Url);
                String responseString = urlUtils.getHtmlContentWithParameters(urlUtils.getParameters());

                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                // Construct a response.
                // string responseString = getFileContent(request.Url.ToString(), response);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
            // Httplistener neither stop ...
            // listener.Stop();
        }

        private static string getFileContent(string url, HttpListenerResponse response)
        {
            string publicDirectory = "www";
            string fileName = url.Substring(22);

            string path = publicDirectory + "\\" + fileName;
            if (fileName == "") fileName = "index.html";

            string res = "404 File Not Found";
            response.StatusCode = 404;
            response.StatusDescription = "Not Found";

            try
            {
                res = File.ReadAllText(path);
                response.StatusCode = 200;
                response.StatusDescription = "OK";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return res;
        }
    }
}