using PointOfSaleTerminal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal.Models
{
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private readonly Dictionary<string, IProduct> _products = new();
        private readonly List<string> _scanTypes = new();
        private readonly ILog _log;

        public string ScanTypes { get => string.Join("",_scanTypes); }

        public PointOfSaleTerminal(ILog log)
        {
            _log = log;
        }

        public double CalculateTotal()
        {
            double result = 0.0;

            var scanGroups = _scanTypes.GroupBy(x => x).Select(x => new { type = x.Key, count = x.Count()}).ToList();

            foreach (var item in scanGroups)
            {
                try
                {
                    checked
                    {
                        result += _products[item.type].CalculateTotal(item.count); 
                    }
                }
                catch (DivideByZeroException)
                {
                    _log.LogMessage($"{nameof(PointOfSaleTerminal)}: Divide by zero during calculation.");
                    throw;
                }
                catch (OverflowException)
                {
                    _log.LogMessage($"{nameof(PointOfSaleTerminal)}: To big price to calculate.");
                    throw;
                }
            }

            return result;
        }

        public void Scan(string typeProduct)
        {
            if (_products.ContainsKey(typeProduct))
            {
                _scanTypes.Add(typeProduct);
            }
            else
            {
                _log.LogMessage($"{nameof(PointOfSaleTerminal)}: Can't scan. Such type of product: {typeProduct} is unknown");
            }
        }

        public void SetPricing(List<IProduct> products)
        {
            _ = products ?? throw new ArgumentNullException(nameof(products));

            foreach (var product in products)
            {
                Validate(product);

                if (!_products.ContainsKey(product.TypeProduct))
                {
                    _products.Add(product.TypeProduct, product);
                }
                else
                {
                    _log.LogMessage($"{nameof(PointOfSaleTerminal)}: Can't set price. Such type of product: {product.TypeProduct} is exist");
                }
            }
        }

        private void Validate(IProduct product)
        {
            _ = product ?? throw new ArgumentNullException(nameof(product));

            var volume = product.VolumePrice.VolumeDiscount;

            if (volume.HasValue && volume == 0)
            {
                throw new ArgumentException(nameof(product.VolumePrice.VolumeDiscount));
            }
        }
    }
}
