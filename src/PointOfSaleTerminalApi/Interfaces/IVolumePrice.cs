namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IVolumePrice
    {
        string ProductCode { get; set; }

        double? PriceDiscount { get; set; }

        double PricePerUnit { get; set; }

        int? VolumeDiscount { get; set; }

        double CalculatePrice(int totalVolume);
    }
}