using Model.Items;
using NUnit.Framework;

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
    }
}