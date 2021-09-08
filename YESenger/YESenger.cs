using System;
using YESenger.Client;
using YESenger.Server;

namespace YESenger
{
    class YESenger
    {
        static void Main(string[] args)
        {
            string username = null;
            string serverIP = null;

            Console.WriteLine("---------- YESenger ----------");
            Console.WriteLine("[1] Run Server\n[2] Run Client");
            Console.Write(">");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("\nPodaj IP serwera: ");
                    serverIP = Console.ReadLine();
                    Console.Write("\nPodaj swoj nick (bez polskich znakow): ");
                    username = Console.ReadLine();
                    ServerService.RunServer(serverIP, username);
                    break;

                case "2":
                    Console.Write("\nPodaj IP serwera: ");
                    serverIP = Console.ReadLine();
                    Console.Write("\nPodaj swoj nick (bez polskich znakow): ");
                    username = Console.ReadLine();
                    ClientService.RunClient(serverIP, username);
                    break;

                default:
                    Console.WriteLine("Zla opcja!");
                    break;
            }
        }
    }
}
