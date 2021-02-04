using Model.Items;
using System;

namespace IdleChopper.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Axe axe = new Axe();

            Console.WriteLine("SINGLE");

            axe.Quantity = 0;
            Console.WriteLine(axe.GetSinglePurchaseCost());
            axe.Quantity = 1;
            Console.WriteLine(axe.GetSinglePurchaseCost());
            axe.Quantity = 10;
            Console.WriteLine(axe.GetSinglePurchaseCost());
            axe.Quantity = 100;
            Console.WriteLine(axe.GetSinglePurchaseCost());
            axe.Quantity = 1000;
            Console.WriteLine(axe.GetSinglePurchaseCost());
            axe.Quantity = 3500;
            Console.WriteLine(axe.GetSinglePurchaseCost());

            Console.WriteLine("BULK");

            axe.Quantity = 0;
            Console.WriteLine(axe.GetBulkPurchaseCost(3));
            Console.WriteLine(axe.GetBulkPurchaseCost(30));
            Console.WriteLine(axe.GetBulkPurchaseCost(300));
            Console.WriteLine(axe.GetBulkPurchaseCost(1000));
            Console.WriteLine(axe.GetBulkPurchaseCost(3500));

            Console.ReadLine();
        }
    }
}
