using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ContractStations
{
    class ExternalInvoker
    {
        public String getResult()
        {
            //
            // Set up the process with the ProcessStartInfo class.
            // https://www.dotnetperls.com/process
            //
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\barna\Documents\PS7\tigli\eiin839\TD3\ConsoleApp1\bin\Debug\ConsoleApp1.exe"; // Specify exe name.
            start.Arguments = ""; // Specify arguments.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            //
            // Start the process.
            //
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (System.IO.StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }

        // returns a list with all contracts names
        public List<String> getContractsNames()
        {
            // TODO kefa
            List<String> res = new List<String>();
            return res;
        } 
    }
}
