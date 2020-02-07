using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class PurchaseMenu
    {
        static void Main(string[] args) //may need to change
        {


            //Purchase Process Flow

            //Purchasing Process Menu
            //Console.WriteLine("(1) Feed Money");
            //        Console.WriteLine("(2) Select Product");
            //        Console.WriteLine("(3) Finish Transaction \r\n");

            //        // The current money provided should start at $0.00 
            //        Money customerFunds = new Money(amount); //parameter, need assistance
            //Console.WriteLine($"Current Money Provided: {customerFunds.MoneyProvided:C}");

            // this is if Feed Money is selected

            Money insertedMoney = new Money(); //call on Money's constructor

            Console.WriteLine("Please insert money. Whole dollar amounts only.");
            string input = Console.ReadLine().Trim();
            decimal amountInserted = decimal.Parse(input); //amountInserted, from Money.cs



            //if (2) Select Product is chosen, display all items available

            VendingMachine display = new VendingMachine();

            display.DisplayItems();

            Console.WriteLine("Please enter the code for your desired product. For example: A1");
            string itemNumber = Console.ReadLine().Trim();  //from VendingMachine.cs


            //When item is dispensed, we return a message based on what is purchased
             //Calling on abstract class 'VendingItem'
             // "MessageWhenDelivered" needs to happen here


            // Money.cs is used to substract money 'amountToRemove' from the inserted amount.

            // (2) Select item can happen repeatedly, until money runs out. **"RemoveMoney" property**



            // (3) Finish Transaction **GiveChange Method. Line 54- end of Money.cs will be enacted.


            // Return to MainMenu
            

        }



    }
}
