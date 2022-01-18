namespace PointOfSaleTerminal.Interfaces
{
    public interface IVolumePrice
    {
        double? PriceDiscount { get; set; }

        double PricePerUnit { get; set; }

        int? VolumeDiscount { get; set; }

        double CalculatePrice(int totalVolume);
    }
}