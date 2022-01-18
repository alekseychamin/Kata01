using Moq;
using NUnit.Framework;
using PointOfSaleTerminalApi.Interfaces;
using PointOfSaleTerminalApi.Models;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture]
    public class PriceSetterTests
    {
        private IPriceSetter _priceSetter;
        private Mock<ILog> _logMock;

        [SetUp]
        public void Init()
        {
            _logMock = new Mock<ILog>();
            _priceSetter = new PriceSetter(_logMock.Object);
        }

        [Test]
        public void SetPricingSuccessfull()
        {
            // Arrange
            List<IPriceList> prices = new()
            {
                new PriceList() { ProductCode = "A", PricePerUnit = 1.25, Discount = new Discount() { Volume = 2, Price = 2.22 } },
                new PriceList() { ProductCode = "B", PricePerUnit = 2.25},
                new PriceList() { ProductCode = "C", PricePerUnit = 3.25 }
            };

            // Act
            _priceSetter.SetPricing(prices);

            // Assert
            CollectionAssert.AreEqual(prices, _priceSetter.Prices.Values);
        }

        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 0)]
        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        public void SetPricingThrowsArgumentException(double pricePerUnit, int volumeDiscount, double priceDiscount)
        {
            // Arrange
            List<IPriceList> prices = new()
            {
                new PriceList()
                {
                    ProductCode = "A",
                    PricePerUnit = pricePerUnit,
                    Discount = new Discount()
                    {
                        Volume = volumeDiscount,
                        Price = priceDiscount
                    }
                }
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _priceSetter.SetPricing(prices));
        }
    }
}
