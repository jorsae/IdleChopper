using Model.Items;
using System;

namespace IdleChopper.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Axe axe = new Axe();
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

            Console.ReadLine();
        }
    }
}
