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

        public UrlAnalyzer(Uri uri)
        {
            this.uri = uri;
        }

        public System.Collections.Specialized.NameValueCollection getParameters()
        {
            return HttpUtility.ParseQueryString(uri.Query);
        }

        public String getHtmlContentWithParameters(System.Collections.Specialized.NameValueCollection parameters)
        {
            String res = "<HTML><BODY> Hello ";
            int count = 0;

            foreach (string key in parameters.AllKeys)
            {
                string[] values = parameters.GetValues(key);
                // res += 
                foreach (string value in values)
                {
                    if (count == 0) res += " ";
                    else res += " et ";

                    res += value + " ";
                }
                count++;
            }

            return res + "</BODY></HTML>";
        }
    }
}
