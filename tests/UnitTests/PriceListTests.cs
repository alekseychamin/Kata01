using Moq;
using NUnit.Framework;
using PointOfSaleTerminalApi.Interfaces;
using PointOfSaleTerminalApi.Models;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture]
    public class PriceListTests
    {
        private IPriceList _priceList;
        private Mock<ILog> _logMock;

        [SetUp]
        public void Init()
        {
            _logMock = new Mock<ILog>();
            _priceList = new PriceList(_logMock.Object);
        }

        [Test]
        public void SetPricingSuccessfull()
        {
            // Arrange
            List<IProduct> products = new()
            {
                new Product() { ProductCode = "A", PricePerUnit = 1.25, Discount = new() { Volume = 2, Price = 2.22 } },
                new Product() { ProductCode = "B", PricePerUnit = 2.25},
                new Product() { ProductCode = "C", PricePerUnit = 3.25 }
            };

            // Act
            _priceList.SetPricing(products);

            // Assert
            CollectionAssert.AreEqual(products, _priceList.Prices.Values);
        }

        [TestCase("A", 0, 1, 1)]
        [TestCase("A", 1, 0, 1)]
        [TestCase("A", 1, 1, 0)]
        [TestCase("A", -1, 1, 1)]
        [TestCase("A", 1, -1, 1)]
        [TestCase("A", 1, 1, -1)]
        [TestCase("", 1, 1, 1)]
        [TestCase(null, 1, 1, 1)]
        public void SetPricingThrowsArgumentException(string productCode, double pricePerUnit, int volumeDiscount, double priceDiscount)
        {
            // Arrange
            List<IProduct> products = new()
            {
                new Product()
                {
                    ProductCode = productCode,
                    PricePerUnit = pricePerUnit,
                    Discount = new()
                    {
                        Volume = volumeDiscount,
                        Price = priceDiscount
                    }
                }
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _priceList.SetPricing(products));
        }

        [Test]
        public void SetPricingThrowsArgumentNulException()
        {
            Assert.Throws<ArgumentNullException>(() => _priceList.SetPricing(null));
        }
    }
}
