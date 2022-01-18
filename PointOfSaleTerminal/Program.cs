using PointOfSaleTerminalApi.Interfaces;
using PointOfSaleTerminalApi.Models;
using System;
using System.Collections.Generic;

namespace PointOfSaleTerminalApi
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog logger = new Logger();
            List<IVolumePrice> prices = new()
            {
                new VolumePrice() { ProductCode = "A", PricePerUnit = 1.25, VolumeDiscount = 3, PriceDiscount = 3 },
                new VolumePrice() { ProductCode = "B", PricePerUnit = 4.25 },
                new VolumePrice() { ProductCode = "C", PricePerUnit = 1, VolumeDiscount = 6, PriceDiscount = 5 },
                new VolumePrice() { ProductCode = "D", PricePerUnit = 0.75 }
            };

            IScaner scaner = new Scaner(logger);
            IPriceSetter priceSetter = new PriceSetter(logger);
            IPriceCalculator priceCalculator = new PriceCalculator(logger);

            IPointOfSaleTerminal terminal = new PointOfSaleTerminal(scaner, priceSetter, priceCalculator);
            
            terminal.SetPricing(prices);

            //ABCDABA
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("C");
            terminal.Scan("D");
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("A");

            try
            {
                logger.LogMessage($"Total price for scans: {terminal.ScanedCodes} = {terminal.CalculateTotal()}");
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Error ocuried during calculation: {ex.Message}");
            }
        }
    }
}
