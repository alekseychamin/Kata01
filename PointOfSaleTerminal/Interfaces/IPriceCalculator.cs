using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IPriceCalculator
    {
        double CalculateTotal(List<string> scaneCodes, Dictionary<string, IVolumePrice> prices);
    }
}
