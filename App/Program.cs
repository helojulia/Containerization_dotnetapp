using System;
using System.Net;
using Timer = System.Timers.Timer;

namespace nsPing
{
    public class PingHelo
    {
        static void Main(string[] args)
        {
            //var connectionString = Environment.GetEnvironmentVariable("mongodb://localhost:27017/");
            string url = "www.helo.se"; // Replace with the URL you want to resolve

            Timer timer = new Timer();
            timer.Interval = TimeSpan.FromSeconds(3).TotalMilliseconds;
            // en anonym funktion som endast används, där vi anropar den, alltså till min timer. Eftersom den är async använder vi await före.
            timer.Elapsed += TimerElapsed;
            timer.Start();
            Console.ReadLine();
        }

        public static void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string url = "www.helo.se";
            ResolveIPAddress(url);
        }

        public static void ResolveIPAddress(string url)
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
        }
    }
}