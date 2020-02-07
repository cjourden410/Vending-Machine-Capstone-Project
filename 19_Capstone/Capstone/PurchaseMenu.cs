using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class PurchaseMenu
    {
        private VendingMachine vm;
        public PurchaseMenu(VendingMachine vm)
        {
            this.vm = vm;
        }
        public void Run() //Chris Comment - updated this
        {
            while(true)
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

                Console.Write(@"
                (1) Feed Money
                (2) Select Product
                (3) Finish Transaction

                Please choose an option: ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Current Money Provided: {this.vm.MoneyProvided.ToString("C")}");

                //Money insertedMoney = new Money(); //call on Money's constructor

                string input = Console.ReadLine().Trim();
                //decimal amountInserted = decimal.Parse(input); //amountInserted, from Money.cs
                if(input == "1")
                {
                    Console.WriteLine("How much would you like to input?");
                    while(true)
                    {
                        Console.WriteLine("$1, $2, $5, $10 ");
                        string amountSelected = Console.ReadLine();
                        if (amountSelected != "1" && amountSelected != "2" && amountSelected != "5" && amountSelected != "10")
                        {
                            Console.WriteLine("Please insert a valid amount");
                        }
                        else if (this.vm.money.AddMoney(amountSelected))
                        {
                            Console.WriteLine($"Current Money Provided: {this.vm.MoneyProvided.ToString("C")}");
                            break;
                        }
                    }
                }
                else if(input == "2")
                {
                    while(true)
                    {
                        this.vm.DisplayItems();
                        Console.WriteLine("Please make your selection");
                        string selection = Console.ReadLine().Trim().ToUpper();
                        if(this.vm.ItemExists(selection) && this.vm.GetItem(selection))
                        {
                            Console.WriteLine($"Please enjoy! {this.vm.VendingMachineItems[selection].MessageWhenDelivered}");
                            break;
                        }
                        else if(!this.vm.ItemExists(selection))
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Entry");
                        }
                        else if(this.vm.ItemExists(selection) && this.vm.MoneyProvided >= this.vm.VendingMachineItems[selection].Price)
                        {
                            Console.WriteLine(this.vm.VendingMachineItems[selection].MessageWhenSoldOut);
                        }
                        else if(this.vm.money.MoneyProvided < this.vm.VendingMachineItems[selection].Price)
                        {
                            Console.WriteLine(this.vm.NotEnoughMoney);
                            break;
                        }
                    }
                }
                else if(input == "3")
                {
                    Console.WriteLine("Finish Transaction");
                    Console.WriteLine(this.vm.money.GiveChange());
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again.");
                }
                Console.ReadLine();

                //if (2) Select Product is chosen, display all items available

                //VendingMachine display = new VendingMachine();

                //display.DisplayItems();

                //Console.WriteLine("Please enter the code for your desired product. For example: A1");
                //string itemNumber = Console.ReadLine().Trim();  //from VendingMachine.cs


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
}
