using System;
using System.Net;

namespace DevUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(">---> dup <---<");
            if (args[0] == "gradle")
            {
                if (args.Length != 3)
                {
                    Console.WriteLine("Not enough args.");
                }
                else
                {
                    Console.WriteLine("Downloading the latest Gradle distribution near you...");
                    if (args[1] == "-o")
                    {
                        Console.WriteLine("Downloading...");
                        WebClient wc = new WebClient();
                        wc.DownloadFileAsync(new Uri("https://services.gradle.org/distributions/gradle-7.0-rc-2-bin.zip"), args[2]);
                        Console.WriteLine("Worked!");
                    }
                }
            }
            else if (args[0] == "eclipse")
            {
                if (args.Length != 3)
                {
                    Console.WriteLine("Not enough args.");
                }
                else
                {
                    Console.WriteLine("Downloading the latest Eclipse distribution near you...");
                    if (args[1] == "-o")
                    {
                        Console.WriteLine("Downloading...");
                        WebClient wc = new WebClient();
                        wc.DownloadFileAsync(new Uri("https://www.eclipse.org/downloads/download.php?file=/oomph/epp/2021-03/R/eclipse-inst-jre-win64.exe"), args[2]);
                        Console.WriteLine("Worked!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Unknown command. Commands: gradle, eclipse.");
            }
        }
    }
}
