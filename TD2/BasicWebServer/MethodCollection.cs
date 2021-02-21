using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Specialized;

namespace BasicWebServer
{
    class MethodCollection
    {
        private static int callsNumber = 0;
        public String getExeStreamOutput(String arguments)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            // Specify exe name.
            start.FileName = @"C:\Users\barna\Documents\PS7\tigli\eiin839\TD2\ExecTest\bin\Debug\ExecTest.exe";
            // Specify arguments.
            start.Arguments = arguments; 
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            // Start the process.
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public String getHtmlOpeningContent()
        {
            return "<HTML>\n<head>" +
                "<meta charset=\"utf-8\">" +
                "</head>\n<BODY>\n\n";
        }

        public String getHtmlClosingContent()
        {
            return "\n</BODY></HTML>\n";
        }

        // dynamic content generated with internal methods
        public String getHtmlContentWithParameters(NameValueCollection parameters)
        {
            String res = "<h1>Contenu produit avec des fonctions internes au serveur web</h1>\n<p> Hello";
            int count = 0;

            foreach (string key in parameters.AllKeys)
            {
                string[] values = parameters.GetValues(key);
                foreach (string value in values)
                {
                    if (count == 0) res += " ";
                    else res += " et ";

                    res += value + " ";
                }
                count++;
            }

            return res + "</p>\n\n";
        }

        // displays calls number, increments each time the server gets requested
        public String getCallsNumberHtmlContent()
        {
            return "\n<h2> Nombre de requêtes envoyées au serveur: " + callsNumber + "</h2>\n";
        }

        public void incrementRequestCounter()
        {
            callsNumber++;
        }
    }
}
