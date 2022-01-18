using Moq;
using NUnit.Framework;
using PointOfSaleTerminalApi.Interfaces;
using PointOfSaleTerminalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Dictionary<string, IProduct> prices = new()
            {
                { "A", new Product() { ProductCode = "A", PricePerUnit = 1.25, Discount = new Discount() { Volume = 3, Price = 3 } } },
                { "B", new Product() { ProductCode = "B", PricePerUnit = 4.25 } },
                { "C", new Product() { ProductCode = "C", PricePerUnit = 1, Discount = new Discount() { Volume = 6, Price = 5 } } },
                { "D", new Product() { ProductCode = "D", PricePerUnit = 0.75 } }
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
            Dictionary<string, IProduct> prices = new()
            {
                { "A", new Product() { ProductCode = "A", PricePerUnit = 1.25, Discount = new() { Volume = 0, Price = 3 } } }
            };

            // Act
            List<string> scaneCodes = scanedCodes.Select(x => x.ToString()).ToList();

            // Assert
            Assert.Throws<DivideByZeroException>(() => _priceCalculator.CalculateTotal(scaneCodes, prices));
            _logMock.Verify(x => x.LogMessage(It.IsAny<string>()), Times.Once);
        }
    }
}
