﻿using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            Planet planet;

            [SetUp]
            
            public void SetUp()
            {
                planet = new Planet("Mercury", 505.40);
            }

            [Test]

            public void Test_PlanetWarsConstructor_SetsPropertiesCorrectly()
            {
                Assert.That("Mercury", Is.EqualTo(planet.Name));
                Assert.That(505.40, Is.EqualTo(planet.Budget));
                Assert.True(planet.Weapons != null);
            }

            [Test]

            public void Test_NamePropery_ThrowArgumentException()
            {
                Assert.Throws<ArgumentException>(() =>
                planet = new Planet(string.Empty, 20), "Invalid planet Name"
                );

                Assert.Throws<ArgumentException>(() => 
                planet = new Planet(null, 20), "Invalid planet Name"
                );
            }
        }

        [TestFixture]

        public class WeaponTests
        {

        }
    }
}
