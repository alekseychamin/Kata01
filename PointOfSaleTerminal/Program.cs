using PointOfSaleTerminal.Interfaces;
using PointOfSaleTerminal.Models;
using System;

namespace PointOfSaleTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog logger = new Logger();
            IProduct productA = new Product("A", new VolumePrice() { PricePerUnit = 1.25, VolumeDiscount = 3, PriceDiscount = 3 } );
            IProduct productB = new Product("B", new VolumePrice() { PricePerUnit = 4.25 });
            IProduct productC = new Product("C", new VolumePrice() { PricePerUnit = 1, VolumeDiscount = 6, PriceDiscount = 5 } );
            IProduct productD = new Product("D", new VolumePrice() { PricePerUnit = 0.75 });

            ISaleTerminal terminal = new SaleTerminal(logger);
            
            terminal.SetPricing(productA);
            terminal.SetPricing(productB);
            terminal.SetPricing(productC);
            terminal.SetPricing(productD);

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
