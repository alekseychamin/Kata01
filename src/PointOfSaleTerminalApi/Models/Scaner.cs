using PointOfSaleTerminalApi.Interfaces;
using System.Collections.Generic;

namespace PointOfSaleTerminalApi.Models
{
    public class Scaner : IScaner
    {
        private readonly ILog _log;

        public Scaner(ILog log)
        {
            _log = log;
        }

        public List<string> ScaningCodes { get; } = new();

        public string ScanedCodes => string.Join("", ScaningCodes);

        public void Scan(string productCode, IReadOnlyDictionary<string, IPriceList> prices)
        {
            if (prices is null)
            {
                _log.LogMessage($"{nameof(Scaner)}: Unable to scan: no product code list loaded");
                return;
            }

            if (prices.ContainsKey(productCode))
            {
                ScaningCodes.Add(productCode);
            }
            else
            {
                _log.LogMessage($"{nameof(Scaner)}: Unable to scan: unknown product type: {productCode}");
            }
        }
    }
}
