using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        public Dictionary<string, VendingItem> VendingMachineItems = new Dictionary<string, VendingItem>();
        public Money money { get; }
        private FileLog fileLog = new FileLog();
        VendingItemManager ItemManager = new VendingItemManager();
        public string MessageToUser;
        public string NotEnoughMoney = "Sorry, please insert more money into the machine to complete the transaction. ";
        

        public VendingMachine()
        {
            this.VendingMachineItems = this.ItemManager.GetVendingItems();
            this.money = new Money(this.fileLog); 
        }

        public decimal MoneyProvided
        {
            get
            {
                return this.money.MoneyProvided;
            }
        }

        public void DisplayItems()
        {
            Console.WriteLine($"{"Location",-5} {"Product"} {"Price",40} {"Available",10}");
            // Foreach for Vending Items
            foreach (KeyValuePair<string, VendingItem> kvp in this.VendingMachineItems)
            {
                // If items stock is greater than 0 than show the slot location, product name, price quantity remaining
                if(kvp.Value.ItemsRemaining > 0)
                {
                    // item location
                    string itemLocation = kvp.Key;
                    // Product
                    string itemName = kvp.Value.ProductName;

                    // Price
                    string itemPrice = kvp.Value.Price.ToString("C");

                    // Number Available
                    string itemRemaining = kvp.Value.ItemsRemaining.ToString();

                    Console.WriteLine($"{itemLocation} {itemName} costs {itemPrice} each. There are {itemRemaining} remaining.");
                }
                else
                {
                    // Else return that the item is sold out
                    Console.WriteLine($"{kvp.Key} {kvp.Value.ProductName} is sold out!");

                    // return user to the purchase menu
                }
            }
            
            
        }

        public bool ItemExists(string itemNumber)
        {
            return this.VendingMachineItems.ContainsKey(itemNumber);
        }

        public bool GetItem(string itemNumber)
        {
            // If the item exists and there is stock left and we have the money to buy
            // UPDATED to call remove item method to update the items remaining
            if (this.ItemExists(itemNumber) && this.VendingMachineItems[itemNumber].ItemsRemaining > 0 && this.money.MoneyProvided >= this.VendingMachineItems[itemNumber].Price && this.VendingMachineItems[itemNumber].RemoveItem())
            {
                // Log the item selected
                string message = $"{this.VendingMachineItems[itemNumber].ProductName} {itemNumber}";

                // Log current amount of money in the machine
                decimal before = this.money.MoneyProvided;

                // Remove the money in the machine
                this.money.RemoveMoney(this.VendingMachineItems[itemNumber].Price);

                // Log the money left in the machine
                decimal after = this.money.MoneyProvided;

                // Log message, before, after
                this.fileLog.Log(message, before, after);

                return true;
            }
            else
            {
                return false;

                // this is where customer is informed if product code aka "itemNumber" does not exist.
                //Console.WriteLine is considered 'unreachable' here. Not sure how to fix
                //this issue at the moment.

                //also user has to be returned to the Purchase Menu if the itemNumber does not exist.


            }

        }

    }
}




