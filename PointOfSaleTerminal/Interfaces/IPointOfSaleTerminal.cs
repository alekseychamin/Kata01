﻿using PointOfSaleTerminalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IPointOfSaleTerminal
    {
        string ScanedCodes { get; }

        /// <summary>
        /// Scan the product code
        /// </summary>
        /// <param name="productCode"></param>
        void Scan(string productCode);

        /// <summary>
        /// Set the pricing regarding to the product codes
        /// </summary>
        /// <param name="prices"></param>
        void SetPricing(List<IVolumePrice> prices);

        /// <summary>
        /// Calculate total price of the scaned product codes
        /// </summary>
        /// <returns></returns>
        double CalculateTotal();
    }
}
