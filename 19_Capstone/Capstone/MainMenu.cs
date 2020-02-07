using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenu
    {
        public void Run() //originally wrote in program...may have to remove this
        // Chris Comment - Let's leave this here and just have a basic call to this in the program to keep it as clean as possible. 
        // Referencing Shapes example and renamed this to run
        {
            //Vending Machine Design will be here, along with Main Menu? Or separate, then the menu?

            VendingMachine vm = new VendingMachine();

            while(true)
            {
                Console.Write(@"
                Welcome, Hungry One. Please select an option.

                (1) Display Vending Machine Items
                (2) Purchase
                (3) Exit
                
                Please choose an option: ");
                // Main Menu
                //Console.WriteLine("Welcome, Hungry One. Please select an option. \r\n");
                //Console.WriteLine("(1) Display Vending Machine Items");
                //Console.WriteLine("(2) Purchase");
                //Console.WriteLine("(3) Exit");

                // There is supposed to be 'hidden' per #10 of the instructions. This would write the Sales Report, which is detailed in FileLog.cs.

                string input = Console.ReadLine().Trim();
                int userOption = int.Parse(input);

                if (userOption == 1)
                {
                    // Console.Clear();  will the screen change/clear automatically?
                    //Display Vending Machine Items
                    //VendingMachine display = new VendingMachine(); // Chris Comment - declaired up top so we can remove here
                    Console.WriteLine("Display vending machine items");
                    vm.DisplayItems();
                }

                else if (userOption == 2)
                {
                    ////Purchasing Process Menu
                    //Console.WriteLine("(1) Feed Money");
                    //Console.WriteLine("(2) Select Product");
                    //Console.WriteLine("(3) Finish Transaction \r\n");

                    //// The current money provided should start at $0.00 
                    //Money customerFunds = new Money(amount); //parameter, need assistance
                    //Console.WriteLine($"Current Money Provided: {customerFunds.MoneyProvided:C}");

                    // Simplifying to call a new purchase menu using this info so it sends the user to that menu from here
                    Console.Clear();
                    PurchaseMenu pm = new PurchaseMenu(vm);
                    pm.Run();
                }

                else if (userOption == 3)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                else if (userOption == 4)
                {
                    //call on SalesReport function in FileLog here
                    FileLog salesreport = new FileLog();

                }

                else  // should this be a 'catch'? Chris Comment - thinking we'll be fine with an else
                {
                    Console.WriteLine($"{userOption} is invalid. Please enter 1, 2, or 3. Thank you!");
                }
            }


        }
    }
}
