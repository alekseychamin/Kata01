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

        public Dictionary<string, IVolumePrice> Prices { get; } = new();

        public void SetPricing(List<IVolumePrice> prices)
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
                    _log.LogMessage($"{nameof(PriceSetter)}: Can't set price. Such code of product: {price.ProductCode} is exist");
                }
            }
        }

        private void Validate(IVolumePrice price)
        {
            _ = price ?? throw new ArgumentNullException(nameof(price));

            if (!CheckRange.IsValid(price.PricePerUnit))
            {
                throw new ArgumentException(nameof(price.PricePerUnit));
            }

            if (!CheckRange.IsValid(price.PriceDiscount))
            {
                throw new ArgumentException(nameof(price.PriceDiscount));
            }

            if (!CheckRange.IsValid(price.VolumeDiscount))
            {
                throw new ArgumentException(nameof(price.VolumeDiscount));
            }
        }
    }
}
