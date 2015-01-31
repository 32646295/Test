using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int nA = 0;
            string[] urls = File.ReadAllLines("TextFile1.txt");
            foreach (string u in urls)
            {
                Go(u);
                Console.WriteLine(u);
            }
            Console.ReadLine();
        }
        static string strProxyAuthorization = null;
        static void Go(string Url)
        {
            Uri uri = new Uri(Url);
            NetworkCredential cre = new NetworkCredential("dlnn", "dlnn0771");
            WebProxy proxy = new WebProxy("127.0.0.1", 8888);



            proxy.Credentials = cre;


            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;

            request.PreAuthenticate = true;
            request.KeepAlive = false;

            request.Method = "GET";
            request.Proxy = proxy;
            request.AllowAutoRedirect = true;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            Stream stm = response.GetResponseStream();
            StreamReader sr = new StreamReader(stm);
            string str = sr.ReadToEnd();
        }
    }
}
