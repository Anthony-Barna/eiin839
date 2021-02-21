using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace BasicWebServer
{
    class UrlAnalyzer
    {
        private Uri uri;

        public UrlAnalyzer(Uri uri)
        {
            this.uri = uri;
        }

        public String getMethodName()
        {
            string methods = this.uri.ToString().Substring(22);
            String[] splitedUrl = methods.Split('?')[0].Split('/');
            return splitedUrl[splitedUrl.Length - 1];
        }

        public NameValueCollection getParameters()
        {
            return HttpUtility.ParseQueryString(uri.Query);
        }

        public String buildArgumentsString()
        {
            NameValueCollection parameters = this.getParameters();

            String res = "";
            int count = 0;

            foreach (string key in parameters.AllKeys)
            {
                string[] values = parameters.GetValues(key);
                foreach (string value in values)
                {
                    if (count == parameters.Count - 1) res += value;
                    else res += value + " ";
                }
                count++;
            }
            return res;
        }
    }
}
