using System.Collections.Generic;

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
