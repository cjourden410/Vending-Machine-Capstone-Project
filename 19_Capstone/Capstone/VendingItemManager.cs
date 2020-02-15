using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Capstone
{
    public class VendingItemManager
    {              
        public Dictionary<string, VendingItem> GetVendingItems()
        {
            Dictionary<string, VendingItem> VendingItemList = new Dictionary<string, VendingItem>();

            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, "..\\..\\..\\..");
            Directory.SetCurrentDirectory(filePath);

            if (File.Exists("vendingmachine.csv"))
            {

                try
                {
                    using (StreamReader sr = new StreamReader("vendingmachine.csv"))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();

                            string[] productDetails = line.Split("|");

                            string slotLocation = productDetails[0];
                            string productName = productDetails[1];
                            string price = productDetails[2];
                            string type = productDetails[3];

                            if (!decimal.TryParse(productDetails[2], out decimal productPrice))
                            {
                                productPrice = 0M;
                            }

                            int itemsRemaining = 5;

                            VendingItem item;

                            switch (productDetails[3])
                            {
                                case "Chip":
                                    item = new Chip(productName, productPrice, itemsRemaining);
                                    break;
                                case "Drink":
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

                            VendingItemList.Add(productDetails[0], item);
                        }
                    }

                }
                catch
                {

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
