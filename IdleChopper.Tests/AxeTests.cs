using Model.Items;
using NUnit.Framework;
using System.Collections.Generic;
using System.Numerics;

namespace IdleChopper.Tests
{
    public class Tests
    {
        private Axe axe;

        [SetUp]
        public void Setup()
        {
            axe = new Axe();
        }

        [TestCaseSource("Should_GetSinglePurchaseCost_TestCases")]
        public void Should_GetSinglePurchaseCost(int quantity, BigInteger expectedCost)
        {
            axe.Quantity = quantity;
            BigInteger cost = axe.GetSinglePurchaseCost();
            Assert.AreEqual(expectedCost, cost);
        }

        public static IEnumerable<TestCaseData> Should_GetSinglePurchaseCost_TestCases
        {
            get
            {
                yield return new TestCaseData(0, new BigInteger(10));
                yield return new TestCaseData(1, new BigInteger(12));
                yield return new TestCaseData(2, new BigInteger(14));
                yield return new TestCaseData(10, new BigInteger(61));
                yield return new TestCaseData(50, new BigInteger(91004));
                yield return new TestCaseData(1000, BigInteger.Parse("151791008917224570498495561316069919186730749386725712710838932260047139249510400"));
                yield return new TestCaseData(3500, BigInteger.Parse("136257735395738206916230857132054495467738500388519925987579237134927067594822540123299578662898971488458888141718917660855980181499274705892151186640131293106780597478445797069488995027849045461384947263439926910057522403726781384359193699518138427738260802625783491747255423200"));
            }
        }

        [TestCaseSource("Should_GetBulkPurchaseCost_TestCases")]
        public void Should_GetBulkPurchaseCost(int currentQuantity, int bulkQuantity, BigInteger expectedCost)
        {
            axe.Quantity = currentQuantity;
            BigInteger cost = axe.GetBulkPurchaseCost(bulkQuantity);
            Assert.AreEqual(expectedCost, cost);
        }

        public static IEnumerable<TestCaseData> Should_GetBulkPurchaseCost_TestCases
        {
            get
            {
                yield return new TestCaseData(0, 1, new BigInteger(10));
                yield return new TestCaseData(0, 2, new BigInteger(22));
                yield return new TestCaseData(0, 3, new BigInteger(36));
                yield return new TestCaseData(0, 10, new BigInteger(259));
                yield return new TestCaseData(0, 1000, BigInteger.Parse("758955044586123049953024685125074654529955653815689161482498537329819298278932480"));
                yield return new TestCaseData(0, 3500, BigInteger.Parse("681288676978691148728082796730674028301123951974160207737070785378216534869805658357096617687335714635916588313853179371753899606511243514356337130774501406983294646184484285207787090088080010840244661210927462648396636320732536696640767612319339805216474698808068712113318658048"));
                
                yield return new TestCaseData(1, 1, new BigInteger(12));
                yield return new TestCaseData(2, 1, new BigInteger(14));
                yield return new TestCaseData(10, 10, new BigInteger(1583));

                yield return new TestCaseData(1000, 1, BigInteger.Parse("151791008917224557334459102746421581946977288927921672848952007191408232500297728"));
            }
        }

        [TestCaseSource("Should_GetMaxNumberOfItems_TestCases")]
        public void Should_GetMaxNumberOfItems(int currentQuantity, BigInteger coins, int expectedQuantity)
        {
            axe.Quantity = currentQuantity;
            int quantity = axe.GetMaxNumberOfItems(coins);
            Assert.AreEqual(expectedQuantity, quantity);
        }

        public static IEnumerable<TestCaseData> Should_GetMaxNumberOfItems_TestCases
        {
            get
            {
                yield return new TestCaseData(0, new BigInteger(10), 1);
                yield return new TestCaseData(0, new BigInteger(22), 2);
                yield return new TestCaseData(0, BigInteger.Parse("758955044586123049953024685125074654529955653815689161482498537329819298278932480"), 1000);
                yield return new TestCaseData(0, BigInteger.Parse("681288676978691148728082796730674028301123951974160207737070785378216534869805658357096617687335714635916588313853179371753899606511243514356337130774501406983294646184484285207787090088080010840244661210927462648396636320732536696640767612319339805216474698808068712113318658048"), 3499);
                yield return new TestCaseData(1000, BigInteger.Parse("151791008917224571334459102746421581946977288927921672848952009191408232500297728"), 1);
            }
        }

    }
}