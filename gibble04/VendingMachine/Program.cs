﻿// Exercise 04 
// Gibble, Jay ejg2
using System;

namespace VendingMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PurchasePrice initialPrice = new PurchasePrice(0.55M);
            decimal sodaPrice = initialPrice.PriceDecimal;
            CanRack sodaRack = new CanRack();

            Console.WriteLine("Welcome to the .NET C# Soda Vending Machine.");

            //2.6 - 2.7 this broke string tests
            Boolean timeToExit = false;
            do
            {
                sodaRack.DisplayCanRack();
                Console.Write($"Please insert {sodaPrice:c} cents: ");

                decimal valueInserted = decimal.Parse(Console.ReadLine());
                decimal valueRemaining = sodaPrice - valueInserted;
                bool valueInsertedUnder = valueInserted < sodaPrice;
                bool valueInsertedHigh = valueInserted > 1M;
                bool valueInsertedOver = valueInserted >= sodaPrice;

                Console.WriteLine($"You have inserted {valueInserted:c} cents.");

                if (valueInsertedUnder) Console.WriteLine($"Please enter {valueRemaining:c} cents more to complete your transaction.");
                else if (valueInsertedHigh) Console.WriteLine($"Please enter less than a dollar to complete your transaction.");
                else if (valueInsertedOver)
                {
                    sodaRack.RemoveACanOf(Flavor.LEMON);
                    //sodaRack.AddACanOf(Flavor.LEMON);
                    Console.WriteLine($"Thanks! Here is your soda. Your change is {valueRemaining * -1:c} cents.");
                    Console.Write("Exit the vending machine? (y/n): ");
                    string response = Console.ReadLine();
                    timeToExit = response.Trim().ToUpper().StartsWith("Y");
                }
            } while (!timeToExit);
        }
    }
}

