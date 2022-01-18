namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IPriceList
    {
        string ProductCode { get; set; }

        double PricePerUnit { get; set; }

        IDiscount Discount { get; set; }

        double CalculatePrice(int totalVolume);
    }
}