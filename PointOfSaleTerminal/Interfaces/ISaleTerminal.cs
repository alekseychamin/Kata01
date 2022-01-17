using PointOfSaleTerminal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal.Interfaces
{
    public interface ISaleTerminal
    {
        string ScanTypes { get; }

        void Scan(string typeProduct);

        void SetPricing(IProduct product);

        double CalculateTotal();
    }
}
