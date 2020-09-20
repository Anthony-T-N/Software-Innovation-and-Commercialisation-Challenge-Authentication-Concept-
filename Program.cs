using System;
using System.Collections.Generic;

namespace Authentication_Logic_Concept____Innovation_Challenge_
{
    class Program
    {
        // Global Variables:
        string business_key = "-";
        static string access_point_name = "Business_Name";
        // Code made up of several elements. (Date and time).
        static string store_item_code = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt") + "|" + access_point_name;

        static void Main(string[] args)
        {
            Program main_program = new Program();
            Console.WriteLine("Step 1:");
            // Check whether the customer has purchased an item within 30mins.
            main_program.check_expiry(store_item_code);
            // Verify that the item the customer purchased is from the same store providing wifi.
            main_program.initial_verification(store_item_code);
        }
        public void check_expiry(string store_item_code)
        {
            Console.WriteLine("Check Expiry");
            if ((DateTime.Now - DateTime.Parse(store_item_code.Remove(store_item_code.LastIndexOf('|')))).TotalMinutes <= 30)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid Code");
                System.Environment.Exit(0);
            }
            /*
            store_item_code = "2020-09-18 12:05:00";
            List<string> store_item_code_list = new List<string>()
            {
                store_item_code.Substring(0, 4),
                store_item_code.Substring(5, 2),
                store_item_code.Substring(8, 2),
                store_item_code.Substring(11, 2),
                store_item_code.Substring(14, 2),
                store_item_code.Substring(17, 2),
            };
            List<string> date_time_key_list = new List<string>()
            {
                "yyyy", "MM", "dd", "hh", "mm", "ss"
            };
            // Reads QR code or barcode to extract time/date and compares with current time/date to determine validity.
            Console.WriteLine("Check Expiry");
            string current_time = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            Console.WriteLine(DateTime.Now.ToString("yyyy"));
            Console.WriteLine(DateTime.Now.ToString(current_time));
            for (int i = 0; i <= store_item_code_list.Count - 1; i++)
            {
                Console.WriteLine(date_time_key_list[i] + " " + store_item_code_list[i]);
                // Must be used within 30mins or else code expires.
                if (date_time_key_list[i] == "mm")
                {
                    int temp_current_mm = Int32.Parse(DateTime.Now.ToString(date_time_key_list[i]));
                    int temp_code_item_mm = Int32.Parse(store_item_code_list[i]);
                    Console.WriteLine(temp_current_mm + " >= " + temp_code_item_mm + " " + temp_code_item_mm + " >= " + (temp_current_mm - 30));
                    if (temp_current_mm >= temp_code_item_mm && temp_code_item_mm >= temp_current_mm - 30)
                    {
                        Console.WriteLine("Check: " + date_time_key_list[i]);
                    }
                    else
                    {
                        Console.WriteLine("Expired");
                    }
                }
                else if (Int32.Parse(DateTime.Now.ToString(date_time_key_list[i])) == Int32.Parse(store_item_code_list[i]))
                {
                    Console.WriteLine("Check: " + date_time_key_list[i]);
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
            */
            /*
            // Check for illegitimate time/dates.
            if (Int32.Parse(DateTime.Now.ToString("yyyy")) >= Int32.Parse(store_item_code.Substring(0, 4)))
            {
                Console.WriteLine("Year checked");
                if (Int32.Parse(DateTime.Now.ToString("MM")) >= Int32.Parse(store_item_code.Substring(5, 2)))
                {
                    Console.WriteLine("Month checked");
                    if (Int32.Parse(DateTime.Now.ToString("dd")) >= Int32.Parse(store_item_code.Substring(9, 2)))
                    {
                        Console.WriteLine("Day checked");
                    }
                }
            }
            */
        }
        public void initial_verification(string store_item_code)
        {
            Console.WriteLine("Initial Verification");
            Console.WriteLine(store_item_code.Substring(store_item_code.IndexOf('|') + 1));
            if (access_point_name == store_item_code.Substring(store_item_code.IndexOf('|') + 1))
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid Code");
                System.Environment.Exit(0);
            }
        }
        public static string temp(bool test)
        {
            return "!";
        }
    }
}

