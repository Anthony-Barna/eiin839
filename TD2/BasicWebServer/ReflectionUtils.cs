using System;
using System.Reflection;
using System.Collections.Specialized;

namespace BasicWebServer
{
    class ReflectionUtils
    {
        public String executeMethod(UrlAnalyzer urlUtils)
        {
            String methodName = urlUtils.getMethodName();

            if (methodName == null || methodName.Equals("favicon.ico")) return "";

            Type type = typeof(MethodCollection);
            MethodInfo method = type.GetMethod(methodName);
            MethodCollection c = new MethodCollection();

            try
            {
                if(methodName.Equals("getHtmlContentWithParameters"))
                {
                    return (string)method.Invoke(c, new Object[] { urlUtils.getParameters() });
                }
                else if (methodName.Equals("getExeStreamOutput"))
                {
                    return (string)method.Invoke(c, new Object[] { urlUtils.buildArgumentsString() });
                }
                return (string)method.Invoke(c, null);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("\nLa méthode " + methodName + " est inconnue");
                Console.WriteLine(e.StackTrace);
                return "";
            }
        }
    }
}
