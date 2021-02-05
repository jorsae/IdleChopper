using Microsoft.VisualBasic.CompilerServices;
using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace IdleChopper.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Axe axe = new Axe();
            WoodTruck woodTruck = new WoodTruck();

            Dictionary<string, BaseItem> Items = new Dictionary<string, BaseItem>
            {
                { axe.Name, axe },
                { woodTruck.Name, woodTruck }
            };

            foreach(var (itemName, item) in Items)
            {
                if(item is BaseClickItem)
                {
                    Console.WriteLine($"ClickItem {itemName}: {item.BaseDamage}");
                }
                if(item is BaseIdleItem)
                {
                    Console.WriteLine($"IdleItem  {itemName}: {item.BaseDamage}");
                }
            }

            Console.WriteLine(Items["Axe"].GetType());


            Console.WriteLine("Classes");
            Console.WriteLine();
        }
        static void CostTest()
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

            Console.WriteLine("MaxUpgrades");

            var last = 0;
            axe.Quantity = 0;
            /*
            for(var i = 0; i < 2147000000; i++)
            {
                BigInteger bb = axe.GetMaxNumberOfUpgrades(new BigInteger(i));
                if(bb != last)
                {
                    Console.WriteLine($"{i}: {bb}");
                    last = (int)bb;
                }
            }*/

            // gives: 3491
            var a = BigInteger.Parse("136257735395738206916230857132054495467738500388519925987579237134927067594822540123299578662898971488458888141718917660855980181499274705892151186640131293106780597478445797069488995027849045461384947263439926910057522403726781384359193699518138427738260802625783491747255423200");
            //Console.WriteLine($"{axe.GetMaxNumberOfUpgrades(a)}");

            var a2 = BigInteger.Parse("681288676978691148728082796730674028301123951974160207737070785378216534869805658357096617687335714635916588313853179371753899606511243514356337130774501406983294646184484285207787090088080010840244661210927462648396636320732536696640767612319339805216474698808068712113318658048");
            //Console.WriteLine($"{axe.GetMaxNumberOfUpgrades(a2)}");

            BigInteger iterator = BigInteger.Parse("151791008917224557334459102746421581946977288927921672848952009191408232500297728");
            axe.Quantity = 1000;
            while (true)
            {
                int bb = axe.GetMaxNumberOfItems(iterator);
                Console.WriteLine($"{bb}: {iterator}");
                if (bb == 1)
                {
                    Console.WriteLine($"{bb}");
                    Console.ReadLine();
                }
                iterator += BigInteger.Parse("1000000000000000000000000000000000000000000000000000000000000000");
            }

            Console.ReadLine();
        }
    }
}