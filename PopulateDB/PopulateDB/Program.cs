using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PopulateDB
{
    class Program
    {
        static void Main(string[] args)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                {
                    WebClient Client = new WebClient();
                    string url = "https://10.26.32.200/DataLog.html?FileName=temperaturacamaras.csv";
                    string destino = @"C:\LogPLC\temperaturacamaras.csv";
                    ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                    Client.DownloadFile(url, destino);
                }
            }
        }
    }
}
