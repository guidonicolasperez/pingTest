using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;


namespace PingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Ping... ");

            Ping ping = new Ping();
            PingReply pingReply;
            string ipAddress = "";

            FileManager FM = new FileManager();




            string pathFileSuccess = Directory.GetCurrentDirectory() + "\\Success\\";
            string pathFileNotSuccess = Directory.GetCurrentDirectory() + "\\NotSuccess\\";

            string fileName = DateTime.Now.Year + "-"
                    + DateTime.Now.Month + "-"
                    + DateTime.Now.Day + "-"
                    + DateTime.Now.Hour + ".txt";

            bool salida = true;

            List<string> lines = FM.readFile(Directory.GetCurrentDirectory() + "\\ip.txt");


            if (lines.Count > 0)
            {
                ipAddress = lines[0];

                while (salida)
                {
                    Console.WriteLine("Haciendo ping a " + ipAddress);

                    fileName = DateTime.Now.Year + "-"
                     + DateTime.Now.Month + "-"
                     + DateTime.Now.Day + "-"
                     + DateTime.Now.Hour + ".txt";

                    pingReply = ping.Send(ipAddress);

                    if (pingReply.Status.ToString().Equals("Success"))
                    {
                        Console.WriteLine(pingReply.Status.ToString() + " " + DateTime.Now);
                        FM.insertAndSaveFile(pathFileSuccess + "Success in " + fileName, (pingReply.Status.ToString() + " " + DateTime.Now));
                    }
                    else
                    {
                        Console.WriteLine(pingReply.Status.ToString() + " " + DateTime.Now);
                        FM.insertAndSaveFile(pathFileNotSuccess + "Not Success in " + fileName, (pingReply.Status.ToString() + " " + DateTime.Now));

                    }

                    System.Threading.Thread.Sleep(1000);

                }

            }
            else
            {
                Console.WriteLine("Ocurrio un error. Revisar Archivo IP.txt");
            }

        }
    }
}
