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

        /// <summary>
        /// Scan code of the product with validations
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="prices"></param>
        void Scan(string productCode, Dictionary<string, IVolumePrice> prices);
    }
}
