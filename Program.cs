using System;

namespace Authentication_Logic_Concept____Innovation_Challenge_
{
    class Program
    {
        // Global Variables:
        string business_key = "-";
        string access_point_name = "Business_Name";
        // Code made up of several elements. (Date and time).
        static string store_item_code = "TEST2020-09-16";

        static void Main(string[] args)
        {
            Program main_program = new Program();
            Console.WriteLine("Step 1:");
            main_program.check_expiry(store_item_code);
        }
        public void check_expiry(string store_item_code)
        { 
            // Reads QR code or barcode to extract time/date and compares with current time/date to determine validity.
            Console.WriteLine("Check Expiry");
            string current_time = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            Console.WriteLine(DateTime.Now.ToString("yyyy"));
            string year = 

            // Check for illegitimate time/dates.
            if (DateTime.Now.ToString("yyyy") <= )
            {

            }

        }
        public void initial_verification(string current_path)
        {
            Console.WriteLine("Initial Verification");
        }
        public static string ---(bool ---)
        {
            return "!";
        }
    }
}
