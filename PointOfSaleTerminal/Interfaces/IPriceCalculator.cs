using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IPriceCalculator
    {
        /// <summary>
        /// Calculate total price of the following scane codes using the prices
        /// </summary>
        /// <param name="scaneCodes"></param>
        /// <param name="prices"></param>
        /// <returns></returns>
        double CalculateTotal(List<string> scaneCodes, Dictionary<string, IVolumePrice> prices);
    }
}
