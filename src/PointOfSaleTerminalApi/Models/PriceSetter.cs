using PointOfSaleTerminalApi.Interfaces;
using System;
using System.Collections.Generic;

namespace PointOfSaleTerminalApi.Models
{
    public class PriceSetter : IPriceSetter
    {
        private readonly ILog _log;

        public PriceSetter(ILog log)
        {
            _log = log;
        }

        public Dictionary<string, IPriceList> Prices { get; } = new();

        public void SetPricing(IEnumerable<IPriceList> prices)
        {
            _ = prices ?? throw new ArgumentNullException(nameof(prices));

            foreach (var price in prices)
            {
                Validate(price);

                if (!Prices.ContainsKey(price.ProductCode))
                {
                    Prices.Add(price.ProductCode, price);
                }
                else
                {
                    _log.LogMessage($"{nameof(PriceSetter)}: Unable to set price: product code {price.ProductCode} already exists");
                }
            }
        }

        private void Validate(IPriceList price)
        {
            _ = price ?? throw new ArgumentNullException(nameof(price));

            if (string.IsNullOrEmpty(price.ProductCode))
            {
                throw new ArgumentException(nameof(price.ProductCode));
            }
            
            if (price.PricePerUnit <= 0)
            {
                throw new ArgumentException(nameof(price.PricePerUnit));
            }

            if (price.Discount?.Price <= 0)
            {
                throw new ArgumentException(nameof(price.Discount.Price));
            }

            if (price.Discount?.Volume <= 0)
            {
                throw new ArgumentException(nameof(price.Discount.Volume));
            }
        }
    }
}
