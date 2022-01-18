using PointOfSaleTerminalApi.Interfaces;

namespace PointOfSaleTerminalApi.Models
{
    public class PriceList : IPriceList
    {
        public string ProductCode { get; set; }

        public double PricePerUnit { get; set; }

        public IDiscount Discount { get; set; }

        public double CalculatePrice(int totalVolume)
        {
            int volumeTotalDiscount = (Discount != null) ? totalVolume / Discount.Volume : 0;
            int volumeTotalPerUnit = (Discount != null) ? totalVolume % Discount.Volume : totalVolume;

            return ((Discount != null) ? volumeTotalDiscount * Discount.Price : 0.0) + volumeTotalPerUnit * PricePerUnit;
        }
    }
}
