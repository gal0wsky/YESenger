using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace YESenger.Server
{
    public static class ServerService
    {
        public static void RunServer(string serverIP, string username)
        {
            List<string> connectedUsers = new List<string>();

            using HttpListener listener = new HttpListener();
            listener.Prefixes.Add($"http://{serverIP}:6968/yesenger/");
            listener.Start();

            string input, msg;

            Console.WriteLine("Starting server..........");
            Console.WriteLine($"{username} connecting..........\n\n");

            connectedUsers.Add(username);

            while (true)
            {
                Console.Write($"{username}>");
                input = Console.ReadLine();
                if (input.Contains("!stop"))
                    break;

                HttpListenerContext context = listener.GetContext();

                msg = $"{username} > " + input;
                context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(msg);
                context.Response.StatusCode = (int)HttpStatusCode.OK;

                using Stream stream = context.Response.OutputStream;
                using StreamWriter writer = new StreamWriter(stream);

                writer.Write(msg);
            }
        }
    }
}
