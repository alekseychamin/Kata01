using PointOfSaleTerminalApi.Interfaces;

namespace PointOfSaleTerminalApi.Models
{
    public class VolumePrice : IVolumePrice
    {
        public string ProductCode { get; set; }

        public int? VolumeDiscount { get; set; }

        public double? PriceDiscount { get; set; }

        public double PricePerUnit { get; set; }

        public double CalculatePrice(int totalVolume)
        {
            int volumeTotalDiscount = (VolumeDiscount.HasValue) ? totalVolume / VolumeDiscount.Value : 0;
            int volumeTotalPerUnit = (VolumeDiscount.HasValue) ? totalVolume % VolumeDiscount.Value : totalVolume;

            return ((PriceDiscount.HasValue) ? volumeTotalDiscount * PriceDiscount.Value : 0.0) + volumeTotalPerUnit * PricePerUnit;
        }
    }
}
