using PointOfSaleTerminalApi.Interfaces;
using System.Collections.Generic;

namespace PointOfSaleTerminalApi.Models
{
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private readonly IScaner _scaner;
        private readonly IPriceSetter _priceSetter;
        private readonly IPriceCalculator _priceCalculator;

        public string ScanedCodes { get => _scaner.ScanedCodes; }

        public PointOfSaleTerminal(IScaner scaner, IPriceSetter priceSetter, IPriceCalculator priceCalculator)
        {
            _priceSetter = priceSetter;
            _scaner = scaner;
            _priceCalculator = priceCalculator;
        }
        
        public double CalculateTotal()
        {
            return _priceCalculator.CalculateTotal(_scaner.ScaningCodes, _priceSetter.Prices);
        }
        
        public void Scan(string productCode)
        {
            _scaner.Scan(productCode, _priceSetter.Prices);
        }
        
        public void SetPricing(List<IVolumePrice> prices)
        {
            _priceSetter.SetPricing(prices);
        }
    }
}
