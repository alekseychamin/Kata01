using System.Collections.Generic;

namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IPriceSetter
    {
        Dictionary<string, IPriceList> Prices { get; }

        /// <summary>
        /// Set prices for the product codes with validations
        /// </summary>
        /// <param name="prices"></param>
        void SetPricing(IEnumerable<IPriceList> prices);
    }
}
