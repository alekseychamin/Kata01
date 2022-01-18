using System.Collections.Generic;

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
        void SetPricing(IEnumerable<IPriceList> prices);

        /// <summary>
        /// Calculate total price of the scaned product codes
        /// </summary>
        /// <returns></returns>
        double CalculateTotal();
    }
}
