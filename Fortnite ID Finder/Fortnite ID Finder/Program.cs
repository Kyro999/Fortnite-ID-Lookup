using System;
using System.Net;
using Newtonsoft.Json;
namespace Fortnite_ID_Finder
{
    class Program
    {
        public static void Main()
        {
            Main:
            Console.Title = "ID Lookup | By Kyro";
            Console.WriteLine("[Prompt]: Enter Cosmetic Name");
            Console.Write("\n[>]: ");
            string name = Console.ReadLine();
            WebClient wb = new WebClient();
            try
            {
                string h = wb.DownloadString($"https://fortnite-api.com/v2/cosmetics/br/search?name={name}");
                wb.Headers.Add("Authorization", "f6128c99-81ab-4ebb-b354-25ad57933c23");
                Properties.Root root = JsonConvert.DeserializeObject<Properties.Root>(h);
                Console.Clear();
                Console.WriteLine($"Now Displaying {name}.\n\n\nID: {root.data.id}\nPath: {root.data.path}");
                Console.ReadLine();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine($"The emote {name} wasn't found.");
                Thread.Sleep(2000);
                Console.Clear();
                goto Main;
            }
        }
    }
}