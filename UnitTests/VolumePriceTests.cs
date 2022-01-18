using NUnit.Framework;
using PointOfSaleTerminalApi.Interfaces;
using PointOfSaleTerminalApi.Models;
using System;

namespace UnitTests
{
    public class VolumePriceTests
    {
        [TestCase(1.25, 3, 3, 3, 3)]
        [TestCase(1, 6, 5, 6, 5)]
        [TestCase(4.25, null, null, 1, 4.25)]
        [TestCase(0.75, null, null, 2, 1.5)]
        public void VolumePriceCalculatePriceSuccessfullTests(double pricePerUnit, int? volumeDiscount, double? priceDiscount,
            int totalVolume, double totalPrice)
        {
            // Arrange
            IVolumePrice volumePrice = new VolumePrice()
            {
                PricePerUnit = pricePerUnit,
                VolumeDiscount = volumeDiscount,
                PriceDiscount = priceDiscount
            };

            // Act
            var result = volumePrice.CalculatePrice(totalVolume);
            
            // Assert
            Assert.AreEqual(totalPrice, result);
        }

        [TestCase(1.25, 0, 3, 3)]
        [TestCase(1.25, 0, null, 3)]
        [TestCase(0, 0, null, 3)]
        public void VolumePriceCalculatePriceThrowsDivideByZeroExceptionTests(double pricePerUnit, int? volumeDiscount, double? priceDiscount,
            int totalVolume)
        {
            // Arrange
            IVolumePrice volumePrice = new VolumePrice()
            {
                PricePerUnit = pricePerUnit,
                VolumeDiscount = volumeDiscount,
                PriceDiscount = priceDiscount
            };

            // Assert
            Assert.Throws<DivideByZeroException>(() => volumePrice.CalculatePrice(totalVolume));
        }
    }
}