using PointOfSaleTerminal.Interfaces;
using PointOfSaleTerminal.Models;
using System;
using System.Collections.Generic;

namespace PointOfSaleTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog logger = new Logger();
            List<IProduct> products = new()
            {
                new Product("A", new VolumePrice() { PricePerUnit = 1.25, VolumeDiscount = 3, PriceDiscount = 3 }),
                new Product("B", new VolumePrice() { PricePerUnit = 4.25 }),
                new Product("C", new VolumePrice() { PricePerUnit = 1, VolumeDiscount = 6, PriceDiscount = 5 }),
                new Product("D", new VolumePrice() { PricePerUnit = 0.75 })
            };

            IPointOfSaleTerminal terminal = new Models.PointOfSaleTerminal(logger);
            
            terminal.SetPricing(products);

            //ABCDABA
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("C");
            terminal.Scan("D");
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("A");

            logger.LogMessage($"Total price for scans: {terminal.ScanTypes} = {terminal.CalculateTotal()}");
        }
    }
}
