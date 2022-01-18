using NUnit.Framework;
using PointOfSaleTerminalApi.Interfaces;
using PointOfSaleTerminalApi.Models;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    public class ProductTests
    {
        [Test, TestCaseSource(nameof(dataSuccessfullCalculatePrice))]
        public void ProductCalculatePriceSuccessfullTests(IProduct product, int totalVolume, double totalPrice)
        {
            // Act
            var result = product.CalculatePrice(totalVolume);
            
            // Assert
            Assert.AreEqual(totalPrice, result);
        }

        [Test]
        public void ProductCalculatePriceThrowsDivideByZeroExceptionTests()
        {
            // Arrange
            IProduct product = new Product() 
            { 
                ProductCode = "A", 
                PricePerUnit = 1.25, 
                Discount = new() { Price = 3, Volume = 0 }
            };

            // Assert
            Assert.Throws<DivideByZeroException>(() => product.CalculatePrice(0));
        }

        private static object[] dataSuccessfullCalculatePrice = 
        {
            new object[]
            {
                new Product() { ProductCode = "A", PricePerUnit = 1.25, Discount = new() { Price = 3, Volume = 3 } }, 3, 3
            },
            new object[]
            {
                new Product() { ProductCode = "B", PricePerUnit = 4.25, Discount = null }, 1, 4.25
            }
        };
    }
}