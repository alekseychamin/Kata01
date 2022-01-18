using PointOfSaleTerminal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal.Models
{
    public class Product : IProduct
    {
        private readonly string _typeProduct;
        private readonly IVolumePrice _volumePrice;

        public string TypeProduct { get => _typeProduct; }
        public IVolumePrice VolumePrice { get => _volumePrice; }

        public Product(string typeProduct, IVolumePrice volumePrice)
        {
            _typeProduct = typeProduct;
            _volumePrice = volumePrice;
        }

        public double CalculateTotal(int totalVolume)
        {
            return _volumePrice.CalculatePrice(totalVolume);
        }
    }
}
