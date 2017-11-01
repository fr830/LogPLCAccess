using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.IO;
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



                    string myConnectionString;
                    myConnectionString =
                            @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};" +
                            @"Dbq=C:\LogPLC\TempCamDB.accdb;";

                    var con = new OdbcConnection();
                    con.ConnectionString = myConnectionString;
                    con.Open();

                    using (var cmd = new OdbcCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText =
                                @"INSERT INTO Temperaturas " +
                                @"SELECT * FROM [Text;FMT=Delimited;HDR=NO;IMEX=2;CharacterSet=437;ACCDB=YES;Database=C:\LogPLC].[temperaturacamaras#csv];";
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();






                }
            }
        }
    }
}
