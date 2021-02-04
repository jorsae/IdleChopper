using Model.Items;
using NUnit.Framework;
using System;
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
                yield return new TestCaseData(0, 50, new BigInteger(454971));
                yield return new TestCaseData(1, 1, new BigInteger(12));
                yield return new TestCaseData(1, 3, new BigInteger(43));
                yield return new TestCaseData(2, 1, new BigInteger(14));
                yield return new TestCaseData(50, 50, new BigInteger(4140426347));
                yield return new TestCaseData(50, 100, new BigInteger(6906823441888125));
            }
        }
    }
}