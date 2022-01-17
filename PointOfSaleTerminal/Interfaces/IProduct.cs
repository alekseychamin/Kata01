using PointOfSaleTerminal.Models;

namespace PointOfSaleTerminal.Interfaces
{
    public interface IProduct
    {
        IVolumePrice VolumePrice { get; }

        string TypeProduct { get; }

        double CalculateTotal(int totalVolume);
    }
}