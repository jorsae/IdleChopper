using Model.Items;
using NUnit.Framework;

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

        //[TestCase(12, 3, Result = 4)]
        [TestCase(0, ExpectedResult = 10.0)]
        [TestCase(1, ExpectedResult = 12.0)]
        [TestCase(2, ExpectedResult = 14.399999999999999d)]
        [TestCase(400, ExpectedResult = 4.7043369321622199E+32d)]
        public double Assert_GetSinglePurchaseCost(int quantity)
        {
            axe.Quantity = quantity;
            return axe.GetSinglePurchaseCost();
        }
    }
}