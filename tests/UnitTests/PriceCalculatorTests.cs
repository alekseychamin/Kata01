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
    public class PriceCalculatorTests
    {
        private IPriceCalculator _priceCalculator;
        private Mock<ILog> _logMock;

        [SetUp]
        public void Init()
        {
            _logMock = new Mock<ILog>();
            _priceCalculator = new PriceCalculator(_logMock.Object);
        }

        [TestCase("ABCDABA", 13.25)]
        [TestCase("CCCCCCC", 6)]
        [TestCase("ABCD", 7.25)]
        public void CalculateTotalSuccessfullTests(string scanedCodes, double totalPrice)
        {
            // Arrange
            Dictionary<string, IVolumePrice> prices = new()
            {
                { "A", new VolumePrice() { ProductCode = "A", PricePerUnit = 1.25, VolumeDiscount = 3, PriceDiscount = 3 } },
                { "B", new VolumePrice() { ProductCode = "B", PricePerUnit = 4.25 } },
                { "C", new VolumePrice() { ProductCode = "C", PricePerUnit = 1, VolumeDiscount = 6, PriceDiscount = 5 } },
                { "D", new VolumePrice() { ProductCode = "D", PricePerUnit = 0.75 } }
            };

            // Act
            List<string> scaneCodes = scanedCodes.Select(x => x.ToString()).ToList();
            var result = _priceCalculator.CalculateTotal(scaneCodes, prices);

            // Assert
            Assert.AreEqual(totalPrice, result);
        }

        [TestCase("A")]
        public void CalculateTotalThrowsDivideByZeroExceptionTests(string scanedCodes)
        {
            // Arrange
            Dictionary<string, IVolumePrice> prices = new()
            {
                { "A", new VolumePrice() { ProductCode = "A", PricePerUnit = 1.25, VolumeDiscount = 0, PriceDiscount = 3 } }
            };

            // Act
            List<string> scaneCodes = scanedCodes.Select(x => x.ToString()).ToList();

            // Assert
            Assert.Throws<DivideByZeroException>(() => _priceCalculator.CalculateTotal(scaneCodes, prices));
            _logMock.Verify(x => x.LogMessage(It.IsAny<string>()), Times.Once);
        }
    }
}
