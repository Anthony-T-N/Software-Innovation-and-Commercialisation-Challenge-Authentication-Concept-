using System;
using System.Net.Http;
using System.Collections.Generic;
// using Microsoft.WindowsAPICodePack.Net;
using Windows.Devices.WiFi;
using System.Threading.Tasks;

namespace Authentication_Logic_Concept____Innovation_Challenge_
{
    class Program
    {
        // Global Variables:
        // Business key is retrieved from the business's website or locally at the store.
        static string business_key = "";
        // Extract access point names.
        static List<string> access_point_names = new List<string>()
        {
            "Free Wifi!!!123",
            "GUEST",
            "0khc mr23",
            "d4gA0v",
            "FREE Public WiFi",
            "Best Wifi",
            "EAGLE",
            "Store_Wifi_231"
        };
        
        // Code made up of several elements. (Date/time + access point name + part of password).
        // Ideally scrambled to avoid illegitimate modifications.
        static string store_item_code = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt") + "|" + "Store_Wifi_23" + "|" + " password";

        static bool verified = true;

        static void Main(string[] args)
        {
            Program main_program = new Program();

            Console.WriteLine("=========================================================================");
            Console.WriteLine("Step 0): Read barcode/QR details to extract store item code");
            Console.WriteLine(store_item_code);
            Console.WriteLine("=========================================================================");
            Console.WriteLine(" ");

            // Extract avaliable wifi APs and compile into a list.
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Step 1): Scan avaliable wireless access points and add to list");
            var ap_extraction_task = main_program.extract_access_point_names();
            ap_extraction_task.Wait();
            Console.WriteLine("=========================================================================");
            Console.WriteLine(" ");

            // Delete afterwards (Testing purposes).
            access_point_names.Add("Store_Wifi_23");

            // Check whether the customer has purchased an item within 30mins.
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Step 2): Check Expiry of item brought");
            main_program.check_expiry(store_item_code);
            Console.WriteLine("=========================================================================");
            Console.WriteLine(" ");

            // Verify that the item the customer purchased is from the same store providing wifi.
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Step 3): Initial Verification (Loop through wifi list to find a match)");
            verified = main_program.initial_verification(store_item_code);
            Console.WriteLine("=========================================================================");
            Console.WriteLine(" ");

            string extracted_password = "";
            if (verified == true)
            {
                Console.WriteLine("=========================================================================");
                Console.WriteLine("Step 4): Getting 1st part of password from a website");
                var task = main_program.extract_website_password();
                task.Wait();
                Console.WriteLine(business_key);
                Console.WriteLine("=========================================================================");
                Console.WriteLine(" ");

                // Once all steps have been verified, access point password is extracted.
                Console.WriteLine("=========================================================================");
                Console.WriteLine("Step 5): Extract access point password from store_item_code");
                extracted_password = main_program.extract_access_point_password(store_item_code);
                Console.WriteLine(extracted_password);
                Console.WriteLine("=========================================================================");
            }
            else
            {
                System.Environment.Exit(0);
            }
            // Use newly acquired password to access store's access point without the need for the user to enter manually.
            main_program.connect_to_access_point(extracted_password);

            // Delete next two lines.
            Console.WriteLine("Completed - Confirm ?");
            string nil = Console.ReadLine();

        }
        public void check_expiry(string store_item_code)
        {
            if ((DateTime.Now - DateTime.Parse(store_item_code.Remove(store_item_code.IndexOf('|')))).TotalMinutes <= 30)
            {
                Console.WriteLine(DateTime.Now);
                Console.WriteLine("Valid Expiry");
            }
            else
            {
                Console.WriteLine("Invalid Expiry");
                verified = false;
            }
        }
        public bool initial_verification(string store_item_code)
        {
            string current_access_point = store_item_code.Substring(store_item_code.IndexOf('|') + 1, store_item_code.LastIndexOf('|') - store_item_code.IndexOf('|') - 1);
            for (int i = 0; i <= access_point_names.Count - 1; i++)
            {
                if (access_point_names[i] == current_access_point)
                {
                    Console.WriteLine("[+] " + access_point_names[i] + " == " + current_access_point);
                    Console.WriteLine("Valid Access Point");
                    return true;
                }
                Console.WriteLine("[-] " + access_point_names[i] + " || " + current_access_point);
            }
            Console.WriteLine("Invalid Access Point");
            return false;
        }
        public string extract_access_point_password(string store_item_code)
        {
            string password = (business_key + store_item_code.Substring(store_item_code.LastIndexOf('|') + 1));
            return ("Wifi password: " + password);
        }
        public async Task extract_access_point_names()
        {
            /*
            // Credits: https://stackoverflow.com/questions/40645146/how-can-i-get-the-currently-connected-wifi-ssid-and-signal-strength-in-dotnet-co
            // WARNING: Not cross-platform. Only avaliable on Windows. Old (2014).
            var networks = NetworkListManager.GetNetworks(NetworkConnectivityLevels.All);
            foreach (var network in networks)
            {
                var sConnected = ((network.IsConnected == true) ? " (connected)" : " (disconnected)");
                Console.WriteLine("Network : " + network.Name + " - Category : " + network.Category.ToString() + sConnected);
                access_point_names.Add(network.Name);
            }
            */
            // Credits: https://stackoverflow.com/questions/496568/how-do-i-get-the-available-wifi-aps-and-their-signal-strength-in-net?rq=1
            var adapters = await WiFiAdapter.FindAllAdaptersAsync();
            foreach (var adapter in adapters)
            {
                foreach (var network in adapter.NetworkReport.AvailableNetworks)
                {
                    Console.WriteLine($"ssid: {network.Ssid}" + " | " + $"signal strength: {network.SignalBars}");
                    access_point_names.Add(network.Ssid);
                }
            }
        }
        public void connect_to_access_point(string password)
        {

        }
        public async Task extract_website_password()
        {
            HttpClient client = new HttpClient();
            string s = await client.GetStringAsync("https://example.com/");
            s = s.Substring(s.IndexOf("<title>") + "<title>".Length, s.IndexOf("</title>") - s.IndexOf("<title>") - "<title>".Length);
            business_key = s.Substring(0, 7);
        }
    }
}
