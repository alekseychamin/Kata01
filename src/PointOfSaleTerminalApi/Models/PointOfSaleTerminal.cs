using PointOfSaleTerminalApi.Interfaces;
using System.Collections.Generic;

namespace PointOfSaleTerminalApi.Models
{
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private readonly IScaner _scaner;
        private readonly IPriceList _priceList;
        private readonly IPriceCalculator _priceCalculator;

        public string ScanedCodes { get => _scaner.ScanedCodes; }

        public PointOfSaleTerminal(IScaner scaner, IPriceList priceSetter, IPriceCalculator priceCalculator)
        {
            _priceList = priceSetter;
            _scaner = scaner;
            _priceCalculator = priceCalculator;
        }
        
        public double CalculateTotal()
        {
            return _priceCalculator.CalculateTotal(_scaner.ScaningCodes, _priceList.Prices);
        }
        
        public void Scan(string productCode)
        {
            _scaner.Scan(productCode, _priceList.Prices);
        }
        
        public void SetPricing(IEnumerable<IProduct> prices)
        {
            _priceList.SetPricing(prices);
        }
    }
}
