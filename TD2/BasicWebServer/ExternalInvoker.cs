using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Specialized;

namespace BasicWebServer
{
    class ExternalInvoker
    {
        public String buildArgumentsString(NameValueCollection parameters)
        {
            String res = "";
            int count = 0;

            foreach (string key in parameters.AllKeys)
            {
                string[] values = parameters.GetValues(key);
                foreach (string value in values)
                {
                    if (count == parameters.Count-1) res += value;
                    else res += value + " ";
                }
                count++;
            }
            return res;
        }

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
    }
}
