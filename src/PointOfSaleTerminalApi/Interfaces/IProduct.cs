using PointOfSaleTerminalApi.Models;

namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IProduct
    {
        string ProductCode { get; set; }

        double PricePerUnit { get; set; }

        Discount Discount { get; set; }

        double CalculatePrice(int totalVolume);
    }
}