using System;
using System.Threading;
using System.Net;
using Timer = System.Timers.Timer;

namespace nsPing
{
    public class PingHelo
    {
        static void Main(string[] args)
        {
            string url = "www.helo.se";

            Timer timer = new Timer();
            timer.Interval = TimeSpan.FromSeconds(3).TotalMilliseconds;
            timer.Elapsed += (sender, e) =>
            {
                try
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(url);
                    IPAddress[] iPAddresses = hostEntry.AddressList;

                    System.Console.WriteLine($"IP adresses for {url}:");
                    foreach (IPAddress iPAddress in iPAddresses)
                    {
                        System.Console.WriteLine(iPAddress);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"An error occured: {ex.Message}");
                }
            };

            timer.Start();
            Console.ReadLine();
        }
    }
}