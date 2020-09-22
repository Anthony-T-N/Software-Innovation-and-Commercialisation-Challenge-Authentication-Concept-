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
        static string access_point_name = "Business_Name";
        // Code made up of several elements. (Date/time & access point name).
        static string store_item_code = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt") + "|" + access_point_name + "|" + "word";

        static void Main(string[] args)
        {
            Program main_program = new Program();

            // Check whether the customer has purchased an item within 30mins.
            main_program.check_expiry(store_item_code);

            // Verify that the item the customer purchased is from the same store providing wifi.
            main_program.initial_verification(store_item_code);

            main_program.extract_access_point_password(store_item_code);

        }
        public void check_expiry(string store_item_code)
        {
            Console.WriteLine("Check Expiry");
            if ((DateTime.Now - DateTime.Parse(store_item_code.Remove(store_item_code.IndexOf('|')))).TotalMinutes <= 30)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid Code");
                System.Environment.Exit(0);
            }
        }
        public void initial_verification(string store_item_code)
        {
            Console.WriteLine("Initial Verification");
            Console.WriteLine(access_point_name);
            Console.WriteLine(store_item_code.Substring(store_item_code.IndexOf('|') + 1, store_item_code.LastIndexOf('|') - store_item_code.IndexOf('|') + 1));
            if (access_point_name == store_item_code.Substring(store_item_code.IndexOf('|') + 1, store_item_code.LastIndexOf('|') - store_item_code.IndexOf('|') + 1))
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid Code");
                System.Environment.Exit(0);
            }
        }
        public void extract_access_point_password(string store_item_code)
        {
            Console.WriteLine("Extract access point password");
            string password = (business_key + store_item_code.Substring(store_item_code.LastIndexOf('|') + 1));
            Console.WriteLine(password);
        }
    }
}

