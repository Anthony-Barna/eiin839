using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace BasicWebServer
{
    class UrlAnalyzer
    {
        private Uri uri;
        private static int callsNumber = 0;

        public UrlAnalyzer(Uri uri)
        {
            this.uri = uri;
        }

        public System.Collections.Specialized.NameValueCollection getParameters()
        {
            return HttpUtility.ParseQueryString(uri.Query);
        }

        public String getHtmlOpeningContent()
        {
            return "<HTML>\n<head>" +
                "<meta charset=\"utf - 8\">" +
                "</head>\n<BODY>\n\n";
        }

        public String getHtmlClosingContent()
        {
            return "\n</BODY></HTML>\n";
        }

        public String getHtmlContentWithParameters(System.Collections.Specialized.NameValueCollection parameters)
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

        public String getCallsNumberHtmlContent()
        {
            callsNumber++;
            return "\n<h2> Nombre d'appels au serveur: " + (callsNumber/2+1) + "</h2>\n";
        }
    }
}
