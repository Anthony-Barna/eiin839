using System;

namespace ExeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                String res = "<h1>Contenu produit sur appel d'une application externe au serveur web</h1>\n<p> Hello";

                int count = 0;

                foreach (string arg in args)
                {
                    if (count == 0) res += " ";
                    else res += " et ";

                    res += arg + " ";
                    count++;
                }

                res += "</p>";

                Console.WriteLine(res);
            }
        }
    }
}
