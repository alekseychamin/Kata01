using PointOfSaleTerminalApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminalApi.Models
{
    public class Discount : IDiscount
    {
        public int Volume { get; set; }

        public double Price { get; set; }
    }
}
