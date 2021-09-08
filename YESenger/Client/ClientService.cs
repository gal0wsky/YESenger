using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace YESenger.Client
{
    public static class ClientService
    {
        public static async void RunClient(string serverIP, string username)
        {
            string baseUrl = $"http://{serverIP}:6968/yesenger";
            using HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };

            string connectData = $"{serverIP}, {username}";

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(baseUrl, connectData);

            string response = await responseMessage.Content.ReadAsStringAsync();

            Console.WriteLine(response);

            string input, msg;

            while (true)
            {
                Console.Write($"{username}>");
                input = Console.ReadLine();

                msg = $"{username} > " + input;

                responseMessage = await client.PostAsJsonAsync(baseUrl, msg);

                Console.WriteLine(responseMessage.Content.ReadAsStringAsync());
            }
        }
    }
}
