using Moq;
using NUnit.Framework;
using PointOfSaleTerminalApi.Interfaces;
using PointOfSaleTerminalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<IVolumePrice> prices = new()
            {
                new VolumePrice() { ProductCode = "A", PricePerUnit = 1.25, VolumeDiscount = 2, PriceDiscount = 2.22 },
                new VolumePrice() { ProductCode = "B", PricePerUnit = 2.25},
                new VolumePrice() { ProductCode = "C", PricePerUnit = 3.25 }
            };

            // Act
            _priceSetter.SetPricing(prices);

            // Assert
            CollectionAssert.AreEqual(prices, _priceSetter.Prices.Values);
        }

        [TestCase(0, null, null)]
        [TestCase(-1, null, null)]
        [TestCase(1, 0, null)]
        [TestCase(1, -1, null)]
        [TestCase(1, 1, 0)]
        [TestCase(1, 1, -1)]
        public void SetPricingThrowsArgumentException(double pricePerUnit, int? volumeDiscount, double? priceDiscount)
        {
            // Arrange
            List<IVolumePrice> prices = new()
            {
                new VolumePrice() 
                { 
                    ProductCode = "A", 
                    PricePerUnit = pricePerUnit, 
                    VolumeDiscount = volumeDiscount, 
                    PriceDiscount = priceDiscount 
                }
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _priceSetter.SetPricing(prices));
        }
    }
}
