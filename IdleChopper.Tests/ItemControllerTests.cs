using Model.Items;
using NUnit.Framework;
using System.Numerics;

namespace IdleChopper.Tests
{
    public class ItemControllerTests
    {
        private ItemController itemController;

        [SetUp]
        public void Setup()
        {
            itemController = new ItemController();
        }

        [Test]
        public void Should_FillItems()
        {
            Assert.AreEqual(2, itemController.Items.Count);
        }

        [Test]
        public void Should_AddItem()
        {
            Assert.IsTrue(itemController.AddItem("Axe", 1));
            Assert.IsTrue(itemController.AddItem("Helping Axe", 50));
        }

        [Test]
        public void Should_FailToAddItem()
        {
            Assert.IsFalse(itemController.AddItem("notanditem", 1));
        }

        [Test]
        public void Should_IncreaseClickDamage_WhenAddingClickItem()
        {
            itemController.AddItem("Axe", 1);
            Assert.AreEqual(new BigInteger(1), itemController.ClickDamage);
            itemController.AddItem("Axe", 6);
            Assert.AreEqual(new BigInteger(7), itemController.ClickDamage);
        }

        [Test]
        public void Should_NotIncreaseClickDamage_WhenAddingNotClickItem()
        {
            itemController.AddItem("notanditem", 1);
            Assert.AreEqual(new BigInteger(0), itemController.ClickDamage);
            itemController.AddItem("Helping Axe", 1);
            Assert.AreEqual(new BigInteger(0), itemController.ClickDamage);
        }

        [Test]
        public void Should_IncreaseIdleDamage_WhenAddingIdleItem()
        {
            itemController.AddItem("Helping Axe", 1);
            Assert.AreEqual(new BigInteger(1), itemController.IdleDamage);
            itemController.AddItem("Helping Axe", 6);
            Assert.AreEqual(new BigInteger(7), itemController.IdleDamage);
        }

        [Test]
        public void Should_NotIncreaseIdleDamage_WhenAddingNotIdleItem()
        {
            itemController.AddItem("notanditem", 1);
            Assert.AreEqual(new BigInteger(0), itemController.IdleDamage);
            itemController.AddItem("Axe", 1);
            Assert.AreEqual(new BigInteger(0), itemController.IdleDamage);
        }
    }
}