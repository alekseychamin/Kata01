using Moq;
using NUnit.Framework;
using PointOfSaleTerminalApi.Interfaces;
using PointOfSaleTerminalApi.Models;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture]
    public class ScanerTests
    {
        private IScaner _scaner;
        private Mock<ILog> _logMock;

        [SetUp]
        public void Init()
        {
            _logMock = new Mock<ILog>();
            _scaner = new Scaner(_logMock.Object);
        }

        [Test]
        public void ScanSuccessfullTests()
        {
            // Arrange
            Dictionary<string, IProduct> prices = new()
            {
                { "A", null },
                { "B", null },
                { "C", null }
            };

            // Act
            _scaner.Scan("A", prices);
            _scaner.Scan("B", prices);
            _scaner.Scan("C", prices);

            // Assert
            Assert.AreEqual("ABC", _scaner.ScanedCodes);
        }

        [Test]
        public void ScanUnSuccessfullNotContainsKeyInPricesTests()
        {
            // Arrange
            Dictionary<string, IProduct> prices = new()
            {
                { "A", null },
                { "B", null },
                { "C", null }
            };

            // Act
            _scaner.Scan("a", prices);

            // Assert
            _logMock.Verify(x => x.LogMessage(It.IsAny<string>()), Times.Once);
            Assert.AreEqual("", _scaner.ScanedCodes);
        }

        [Test]
        public void ScanUnSuccessfullPricesEqualsNullTests()
        {
            // Arrange
            Dictionary<string, IProduct> prices = null;

            // Act
            _scaner.Scan("A", prices);

            // Assert
            _logMock.Verify(x => x.LogMessage(It.IsAny<string>()), Times.Once);
            Assert.AreEqual("", _scaner.ScanedCodes);
        }
    }
}
