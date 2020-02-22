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
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, "..\\..\\..\\..");
            Directory.SetCurrentDirectory(filePath);
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
    }
}
