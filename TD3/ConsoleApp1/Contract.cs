using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Contract
    {
        public String name { get; set; }
        public String commercial_name { get; set; }
        public List<String> cities { get; set; }
        public String country_code { get; set; }

        public override string ToString() {
            String res =  
                "\t nom : " + name + "\n"
                + "\t nom client : " + name + "\n"
                + "\t Villes : ";

            if(cities != null) foreach(String city in cities) { res += city + " "; }

            res += "\n\t code pays : " + country_code + "\n";

            return res;
        }
    }
}
