using NUnit.Framework;
using PointOfSaleTerminalApi.Interfaces;
using PointOfSaleTerminalApi.Models;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    public class PriceListTests
    {
        [Test, TestCaseSource(nameof(dataSuccessfullCalculatePrice))]
        public void PriceListCalculatePriceSuccessfullTests(IPriceList priceList, int totalVolume, double totalPrice)
        {
            // Arrange
            IPriceList volumePrice = priceList;

            // Act
            var result = volumePrice.CalculatePrice(totalVolume);
            
            // Assert
            Assert.AreEqual(totalPrice, result);
        }

        [Test]
        public void PriceListCalculatePriceThrowsDivideByZeroExceptionTests()
        {
            // Arrange
            IPriceList volumePrice = new PriceList() 
            { 
                ProductCode = "A", 
                PricePerUnit = 1.25, 
                Discount = new() { Price = 3, Volume = 0 }
            };

            // Assert
            Assert.Throws<DivideByZeroException>(() => volumePrice.CalculatePrice(0));
        }

        private static object[] dataSuccessfullCalculatePrice = 
        {
            new object[]
            {
                new PriceList() { ProductCode = "A", PricePerUnit = 1.25, Discount = new() { Price = 3, Volume = 3 } }, 3, 3
            },
            new object[]
            {
                new PriceList() { ProductCode = "B", PricePerUnit = 4.25, Discount = null }, 1, 4.25
            }
        };
    }
}