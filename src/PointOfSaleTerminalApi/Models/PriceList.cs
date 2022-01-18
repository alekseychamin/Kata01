using PointOfSaleTerminalApi.Interfaces;
using System;
using System.Collections.Generic;

namespace PointOfSaleTerminalApi.Models
{
    public class PriceList : IPriceList
    {
        private readonly ILog _log;

        public PriceList(ILog log)
        {
            _log = log;
        }

        public Dictionary<string, IProduct> Prices { get; } = new();

        public void SetPricing(IEnumerable<IProduct> products)
        {
            _ = products ?? throw new ArgumentNullException(nameof(products));

            foreach (var product in products)
            {
                Validate(product);

                if (!Prices.ContainsKey(product.ProductCode))
                {
                    Prices.Add(product.ProductCode, product);
                }
                else
                {
                    _log.LogMessage($"{nameof(PriceList)}: Unable to set price: product code {product.ProductCode} already exists");
                }
            }
        }

        private void Validate(IProduct price)
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
