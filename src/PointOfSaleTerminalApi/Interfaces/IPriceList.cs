using System.Collections.Generic;

namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IPriceList
    {
        Dictionary<string, IProduct> Prices { get; }

        /// <summary>
        /// Set prices from products codes with validations
        /// </summary>
        /// <param name="products"></param>
        void SetPricing(IEnumerable<IProduct> products);
    }
}
