using System;
using System.Collections.Generic;

namespace Authentication_Logic_Concept____Innovation_Challenge_
{
    class Program
    {
        // Global Variables:
        // Business key is retrieved from the business's website or locally at the store.
        string business_key = "pass";
        // Extract access point names.
        static List<string> access_point_names = new List<string>()
        {
            "Store_Wifi_23"
        };
        
        // Code made up of several elements. (Date/time + access point name + part of password).
        // Ideally scrambled to avoid illegitimate modifications.
        static string store_item_code = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt") + "|" + access_point_names[0] + "|" + "word";

        static bool verified = true;

        static void Main(string[] args)
        {
            Program main_program = new Program();

            // Extract avaliable wifi APs and compile into a list.
            main_program.extract_access_point_names();

            // Check whether the customer has purchased an item within 30mins.
            Console.WriteLine("Check Expiry");
            main_program.check_expiry(store_item_code);

            // Verify that the item the customer purchased is from the same store providing wifi.
            Console.WriteLine("Initial Verification");
            main_program.initial_verification(store_item_code);
            string final = "";
            if (verified == true)
            {
                // Once all steps have been verified, access point password is extracted.
                Console.WriteLine("Extract access point password");
                final = main_program.extract_access_point_password(store_item_code);
                Console.WriteLine(final);
            }
            else
            {
                System.Environment.Exit(0);
            }
            // Use newly acquired password to access store's access point without the need for the user to enter manually.
            main_program.connect_to_access_point(final);
        }
        public void check_expiry(string store_item_code)
        {
            if ((DateTime.Now - DateTime.Parse(store_item_code.Remove(store_item_code.IndexOf('|')))).TotalMinutes <= 30)
            {
                Console.WriteLine("Valid Expiry");
            }
            else
            {
                Console.WriteLine("Invalid Code");
                verified = false;
            }
        }
        public void initial_verification(string store_item_code)
        {
            string current_access_point = store_item_code.Substring(store_item_code.IndexOf('|') + 1, store_item_code.LastIndexOf('|') - store_item_code.IndexOf('|') - 1);
            Console.WriteLine(current_access_point);
            for (int i = 0; i <= access_point_names.Count - 1; i++)
            {
                Console.WriteLine(access_point_names[i] + " == " + current_access_point);
                if (access_point_names[i] == current_access_point)
                {
                    Console.WriteLine("Valid Code");
                    verified = true;
                }
                else
                {
                    Console.WriteLine("Invalid Code");
                    verified = false;
                }
            }
        }
        public string extract_access_point_password(string store_item_code)
        {
            string password = (business_key + store_item_code.Substring(store_item_code.LastIndexOf('|') + 1));
            return ("Wifi password: " + password);
        }
        public void extract_access_point_names()
        {
            
        }
        public void connect_to_access_point(string password)
        {

        }
    }
}
