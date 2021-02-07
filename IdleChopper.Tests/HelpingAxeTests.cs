using Model.Items;
using NUnit.Framework;
using System.Collections.Generic;
using System.Numerics;

namespace IdleChopper.Tests
{
    public class HelpingAxeTests
    {
        private HelpingAxe helpingAxe;

        [SetUp]
        public void Setup()
        {
            helpingAxe = new HelpingAxe();
        }

        [Test]
        public void Should_SetPropertiesInConstructor()
        {
            Assert.AreEqual("Helping Axe", helpingAxe.Name);
            Assert.AreEqual(new BigInteger(50), helpingAxe.Basecost);
            Assert.AreEqual(new BigInteger(1), helpingAxe.BaseDamage);
            Assert.AreEqual(1.2, helpingAxe.Multiplier);
            Assert.AreEqual(0, helpingAxe.Quantity);
        }

        [TestCase("Idle Damage: 0/sec", 0)]
        [TestCase("Idle Damage: 10/sec", 1)]
        [TestCase("Idle Damage: 20/sec", 2)]
        [TestCase("Idle Damage: 100/sec", 10)]
        [TestCase("Idle Damage: 1000/sec", 100)]
        [TestCase("Idle Damage: 11390/sec", 1139)]
        public void Should_GetDamageForUI(string expected, int axeQuantity)
        {
            helpingAxe.Quantity = axeQuantity;
            Assert.AreEqual(expected, helpingAxe.GetDamageForUI);
        }

        [TestCaseSource("Should_GetSinglePurchaseCost_TestCases")]
        public void Should_GetSinglePurchaseCost(int quantity, BigInteger expectedCost)
        {
            helpingAxe.Quantity = quantity;
            BigInteger cost = helpingAxe.GetSinglePurchaseCost();
            Assert.AreEqual(expectedCost, cost);
        }

        public static IEnumerable<TestCaseData> Should_GetSinglePurchaseCost_TestCases
        {
            get
            {
                yield return new TestCaseData(0, new BigInteger(50));
                yield return new TestCaseData(1, new BigInteger(60));
                yield return new TestCaseData(2, new BigInteger(72));
                yield return new TestCaseData(10, new BigInteger(309));
                yield return new TestCaseData(50, new BigInteger(455021));
                yield return new TestCaseData(1000, BigInteger.Parse("758955044586122852492477806580349595933653746933628563554194661300235696247552000"));
                yield return new TestCaseData(3500, BigInteger.Parse("681288676978691034581154285660272477338692501942599629937896185674635337974112700616497893314494857442294440708594588304279900907496373529460755933200656465533902987392228985347444975139245227306924736317199634550287612018633906921795968497590692138691304013128917458736277116000"));
            }
        }

        [TestCaseSource("Should_GetBulkPurchaseCost_TestCases")]
        public void Should_GetBulkPurchaseCost(int currentQuantity, int bulkQuantity, BigInteger expectedCost)
        {
            helpingAxe.Quantity = currentQuantity;
            BigInteger cost = helpingAxe.GetBulkPurchaseCost(bulkQuantity);
            Assert.AreEqual(expectedCost, cost);
        }

        public static IEnumerable<TestCaseData> Should_GetBulkPurchaseCost_TestCases
        {
            get
            {
                yield return new TestCaseData(0, 1, new BigInteger(50));
                yield return new TestCaseData(0, 2, new BigInteger(110));
                yield return new TestCaseData(0, 3, new BigInteger(181));
                yield return new TestCaseData(0, 10, new BigInteger(1297));
                yield return new TestCaseData(0, 1000, BigInteger.Parse("3794775222930615249765123425625373272649778269078445807412492686649096491394662400"));
                yield return new TestCaseData(0, 3500, BigInteger.Parse("3406443384893455995550876904636325288457192615112865762104222008995537729567109301971631997397430809744818025939491753007677633092451103055689175193345820009149613443429467605041069773086104404067860381682174589044706545580707935400102705073411645600482750179677091154226271223808"));

                yield return new TestCaseData(1, 1, new BigInteger(60));
                yield return new TestCaseData(2, 1, new BigInteger(72));
                yield return new TestCaseData(10, 10, new BigInteger(8021));

                yield return new TestCaseData(1000, 1, BigInteger.Parse("758955044586122839328441348010701258693900286474824523692307736231596789656977408"));
            }
        }
    }
}