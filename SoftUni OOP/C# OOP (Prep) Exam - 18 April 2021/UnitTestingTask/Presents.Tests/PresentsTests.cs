﻿namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        Present present;

        [SetUp]
        public void SetUp()
        {
            present = new Present("Spas", 2.5);
        }

        [Test]
        public void Test_ConstructorSetPropertiesCorrectly()
        {
            string expectedName = "Spas";
            string actualName = present.Name;

            double expectedMagick = 2.5;
            double actualMagick = present.Magic;

            Assert.That(expectedName, Is.EqualTo(actualName));
            Assert.That(expectedMagick, Is.EqualTo(actualMagick));
        }
    }
}
