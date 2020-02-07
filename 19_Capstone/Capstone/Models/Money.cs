using System;

namespace Capstone
{
    public class Money
    {
        //private Logger log;
        private FileLog fileLog = new FileLog();
        public decimal MoneyProvided { get; private set; }

        public decimal TotalSales { get; private set; }
        public Money(FileLog fileLog)
        {
            this.MoneyProvided = 0;
            this.fileLog = fileLog;
        }

        

        public bool AddMoney(string amount)
        {
            if (!decimal.TryParse(amount, out decimal amountInserted))
            {
                amountInserted = 0M;
                return false;
            }

            string message = $"FEED MONEY: ";

            // Log current amount of money in the machine
            decimal before = this.MoneyProvided;

            // Add the money
            this.MoneyProvided += amountInserted;

            // Log current money in machine after adding
            decimal after = this.MoneyProvided;

            // Log message, before, after
            this.fileLog.Log(message, before, after);

            return true;
        }

        public bool RemoveMoney(decimal amountToRemove)
        {
            if(this.MoneyProvided <= 0)
            {
                return false;
            }
            this.MoneyProvided -= amountToRemove;
            return true;
        }

        public bool TrackSales(decimal salesAdded)
        {
            if (this.MoneyProvided <= 0)
            {
                return false;
            }
            this.MoneyProvided += salesAdded;
            return true;
        }
        public string GiveChange()
        {
            string result = string.Empty;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            string message = $"GIVE CHANGE: ";

            decimal before = this.MoneyProvided;

            if(this.MoneyProvided > 0)
            {
                while(this.MoneyProvided > 0)
                {
                    if(this.MoneyProvided >= 0.25M)
                    {
                        quarters++;
                        this.RemoveMoney(0.25M);
                    }
                    else if(this.MoneyProvided >= 0.10M)
                    {
                        dimes++;
                        this.RemoveMoney(0.10M);
                    }
                    else if(this.MoneyProvided >= 0.05M)
                    {
                        nickels++;
                        this.RemoveMoney(0.05M);
                    }
                }
                result = GetMessage(quarters, dimes, nickels);

                // Log current money in the machine
                decimal after = this.MoneyProvided;

                // Log message, before, after
                this.fileLog.Log(message, before, after);
            }
            else
            {
                result = "No money to return";
            }
            return result;
        }

        private string GetMessage(int quarters, int dimes, int nickels)
        {
            string quarterString = string.Empty;
            string dimeString = string.Empty;
            string nickelString = string.Empty;

            if(quarters > 0)
            {
                quarterString = $"{quarters} quarters";
            }
            if (dimes > 0)
            {
                dimeString = $"{dimes} dimes";
            }
            if (nickels > 0)
            {
                nickelString = $"{nickels} nickels";
            }

            string result = $"Your change is ";

            if (quarters > 0 && dimes > 0 && nickels > 0)
            {
                result += $"{quarterString}, {dimeString} and {nickelString}";
            }
            else if(quarters > 0 && dimes > 0 || quarters > 0 && nickels > 0)
            {
                result += $"{quarterString} and {dimeString}{nickelString}";
            }
            else if (dimes > 0 && nickels > 0)
            {
                result += $"{dimeString} and {nickelString}";
            }
            else if (quarters > 0 || dimes > 0 || nickels > 0)
            {
                result += $"{quarterString}{dimeString}{nickelString}";
            }
            else
            {
                result = "No change to give.";
            }
            return result;
        }
    }
}