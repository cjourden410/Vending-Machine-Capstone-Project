using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Capstone
{
    public class VendingItemManager
    {

        public List<VendingItem> VendingItemList { get; set; }

        
        
        public Dictionary<string, VendingItem> GetVendingItems()
        {
            Dictionary<string, VendingItem> VendingItemList = new Dictionary<string, VendingItem>();
            
            //List<VendingItem> VendingItemList = new List<VendingItem>();
            if(File.Exists("vendingmachine.csv"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader("vendingmachine.csv"))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();

                            string[] productDetails = line.Split("|");

                            string slotLocation = productDetails[1];
                            string productName = productDetails[2];
                            string price = productDetails[3];
                            string type = productDetails[4];

                            if (!decimal.TryParse(productDetails[3], out decimal productPrice))
                            {
                                productPrice = 0M;
                            }

                            int itemsRemaining = 5;

                            VendingItem item;

                            switch (productDetails[4])
                            {
                                case "Chip":
                                    item = new Chip(productName, productPrice, itemsRemaining);
                                    break;
                                case "Beverage":
                                    item = new Beverage(productName, productPrice, itemsRemaining);
                                    break;
                                case "Gum":
                                    item = new Gum(productName, productPrice, itemsRemaining);
                                    break;
                                case "Candy":
                                    item = new Candy(productName, productPrice, itemsRemaining);
                                    break;
                                default: throw new ArgumentOutOfRangeException();
                            }

                            VendingItemList.Add(productDetails[1], item);
                        }
                    }

                }
                catch
                {
                    Console.WriteLine("Ran into an error when trying to open the reference file.");
                }
            }
            else
            {
                Console.WriteLine("The input file is missing. Is this vending machine even real? Are we even real?");
            }
            return VendingItemList;
        }
    }
}
