using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class FileLog
    {
        public void Log(string message, decimal moneyStart, decimal moneyAfter)
        {
            string dir = @"C:\Users\Student\git\c-module-1-capstone-team-8\19_Capstone"; // TODO: Potentially remove later 
            Directory.SetCurrentDirectory(dir); // TODO: Potentially remove later
            DateTime date = DateTime.Now;
            string calendarDate = date.ToString("MM/dd/yyyy hh:mm:ss tt");

            string moneyStartString = moneyStart.ToString("C");

            string moneyAfterString = moneyAfter.ToString("C");

            string logLine = $"{calendarDate} {message} {moneyStartString} {moneyAfterString}";

            try
            {
                using(StreamWriter sw = new StreamWriter("Log.txt", true))
                {
                    sw.WriteLine(logLine);
                }
            }
            catch
            {
                Console.WriteLine("Ran into an error when trying to log the file.");
                return;
            }
        }

        public void SalesReport(string message2, string priceOfItemsSold, string numberOfItemsSold) // get rid of this

        {
            //string directory = Environment.CurrentDirectory;
            //string filename = "SalesReport.txt";
            //string fullPath = Path.Combine(directory, filename);
            string dir = @"C:\Users\Student\git\c-module-1-capstone-team-8\19_Capstone";
            Directory.SetCurrentDirectory(dir);

            //Dictionary<string, VendingItem> totalItemsSold = new Dictionary<string, VendingItem>();

            //totalItemsSold.Add(message2, priceItemSold);


            //int numberSold = int.Parse(numberOfItemsSold);


            //decimal totalSales = 0;

            //string salesLine = $"{message2}|{numberOfItemsSold}";

            //// we want the vending item list, but only the item parameter, which has productName, productPrice, itemsRemaining.
            //try
            //{
            //    using (StreamWriter sw = new StreamWriter("SalesReport.txt", true))
            //    {
            //        sw.WriteLine(salesLine);
            //    }
            //    Console.WriteLine($"{priceOfItemsSold:C)}");
            //}
            //catch
            //{
            //    Console.WriteLine("Ran into an error when trying to make the sales report.");
            //    return;
            //}

        }
    }
}
