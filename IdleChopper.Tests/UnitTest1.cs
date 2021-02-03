using NUnit.Framework;
using Model.Upgrades;

namespace IdleChopper.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(Model.Upgrades.test.A(), "A");
        }
    }
}