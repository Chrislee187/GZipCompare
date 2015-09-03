using System;
using System.Net;

namespace GZipCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = args.Length == 1 ? args[0] : "http://www.bbc.co.uk";

            Console.WriteLine($"Testing: {url}");

            var req = (HttpWebRequest) WebRequest.Create(url);
            req.Headers.Add("Accept-Encoding","gzip, deflate");

            PerformAndLogRequest(req);

            req = (HttpWebRequest)WebRequest.Create(url);
            req.Headers.Add("Accept-Encoding", "");
            PerformAndLogRequest(req);

            Console.ReadLine();
        }

        private static void PerformAndLogRequest(HttpWebRequest req)
        {
            var data = req.GetResponse().GetResponseStream().ToArray();

            Console.WriteLine($"With Accept-Encoding: '{req.Headers["Accept-Encoding"].PadRight(15, ' ')}' : {(double) data.Length/1024d:N2}");
        }
    }
}
