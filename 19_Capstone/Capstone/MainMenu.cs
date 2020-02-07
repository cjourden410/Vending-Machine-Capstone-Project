using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenu
    {
        static void Main(string[] args) //originally wrote in program...may have to remove this
        {
            //Vending Machine Design will be here, along with Main Menu? Or separate, then the menu?


            // Main Menu
            Console.WriteLine("Welcome, Hungry One. Please select an option. \r\n");
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");

            // There is supposed to be 'hidden' per #10 of the instructions. This would write the Sales Report, which is detailed in FileLog.cs.



            string input = Console.ReadLine().Trim();
            int userOption = int.Parse(input);

            if (userOption == 1)
            {
                // Console.Clear();  will the screen change/clear automatically?
                //Display Vending Machine Items
                VendingMachine display = new VendingMachine();

                display.DisplayItems();
            }

            if (userOption == 2)
            {
                //Purchasing Process Menu
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction \r\n");

                // The current money provided should start at $0.00 
                Money customerFunds = new Money(amount); //parameter, need assistance
                Console.WriteLine($"Current Money Provided: {customerFunds.MoneyProvided:C}");
            }

            if (userOption == 3)
            {
                Console.WriteLine("Goodbye!");
            }

            else  // should this be a 'catch'?
            {
                Console.WriteLine("Please enter 1, 2, or 3. Thank you!");
            }


        }
    }
}
