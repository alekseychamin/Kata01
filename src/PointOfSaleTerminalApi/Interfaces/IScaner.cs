using System.Collections.Generic;

namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IScaner
    {
        List<string> ScaningCodes { get; }

        string ScanedCodes { get; }

        /// <summary>
        /// Scan code of the product with validations
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="prices"></param>
        void Scan(string productCode, Dictionary<string, IPriceList> prices);
    }
}
