﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IPriceSetter
    {
        Dictionary<string, IVolumePrice> Prices { get; }

        /// <summary>
        /// Set prices for the product codes with validations
        /// </summary>
        /// <param name="prices"></param>
        void SetPricing(List<IVolumePrice> prices);
    }
}