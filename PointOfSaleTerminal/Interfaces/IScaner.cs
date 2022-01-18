using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IScaner
    {
        List<string> ScaneCodes { get; }

        string ScanedCodes { get; }

        void Scan(string productCode, Dictionary<string, IVolumePrice> prices);
    }
}
