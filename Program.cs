using System;
using System.Collections.Generic;

namespace Authentication_Logic_Concept____Innovation_Challenge_
{
    class Program
    {
        // Global Variables:
        string business_key = "-";
        string access_point_name = "Business_Name";
        // Code made up of several elements. (Date and time).
        static string store_item_code = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");

        static void Main(string[] args)
        {
            Program main_program = new Program();
            Console.WriteLine("Step 1:");
            main_program.check_expiry(store_item_code);
        }
        public void check_expiry(string store_item_code)
        {
            List<string> store_item_code_list = new List<string>()
            {
                store_item_code.Substring(0, 4),
                store_item_code.Substring(5, 2),
                store_item_code.Substring(9, 2),
                store_item_code.Substring(11, 2),
                store_item_code.Substring(13, 2),
                store_item_code.Substring(16, 2),
            };
            // Reads QR code or barcode to extract time/date and compares with current time/date to determine validity.
            Console.WriteLine("Check Expiry");
            string current_time = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            Console.WriteLine(DateTime.Now.ToString("yyyy"));
            Console.WriteLine(DateTime.Now.ToString(current_time));
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
        }
        public void initial_verification(string current_path)
        {
            Console.WriteLine("Initial Verification");
        }
        public static string file_name_generator(bool use_file_ext)
        {
            return "!";
        }
    }
}
