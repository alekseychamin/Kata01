using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IPriceSetter
    {
        Dictionary<string, IVolumePrice> Prices { get; }

        void SetPricing(List<IVolumePrice> prices);
    }
}
