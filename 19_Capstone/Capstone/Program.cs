﻿using System;
using System.Collections.Generic;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            //TODO Add ASCII Later
            Console.Write(@"
             \       /***** |\   |* *   * *  |\        /|    /|******* |    ||||| 
              \     / *     | \  |   * *   * | \      / |   / |   |    |  |||| 
               \   /  ***** |  \ |    *     *|  \    /  |  /--|   |    | |||  
                \ /   *     |   \|    *     *|   \  /   | /   |   |    |  |||
                 /    ***** |    \ * * ***** |    \/    |/    |   |    |   ||||||");

            MainMenu menu = new MainMenu();
            menu.Run();

            Console.WriteLine("Thank you for supporting Umbrella Corp!");
            Console.ReadKey();

        }
    }
}
