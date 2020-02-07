using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class SalesReport
    {
        public static void Main(string[] args)
        {
            string directory = Environment.CurrentDirectory;
            string filename = "SalesReport.txt";
            string fullPath = Path.Combine(directory, filename);

            // Creates a new stream writer
            // FALSE indicates that the file should be overwritten instead of appended to
            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                int totalSales = 0; //adds up sales "since machine was started"

               // foreach loop for vending items sold
               //write name of product sold, along side the number of sales for the item
                // in the loop, add the the prices of items sold 

                {
                    // Prints result of VendingMachine Method
                    //sw.WriteLine(FizzBuzz(i)); //so it's written one line each, not side by side.

                  //  totalSales += price.ItemSold;
                }
                //print total sales outside of the loop
                Console.WriteLine($"Total Sales: {totalSales:C}");
            }

            // After the using statement ends, file has now been written
            // and closed for further writing
        }
    }
}
