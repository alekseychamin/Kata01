using PointOfSaleTerminalApi.Interfaces;
using System.Collections.Generic;

namespace PointOfSaleTerminalApi.Models
{
    public class Scaner : IScaner
    {
        private readonly List<string> _scaneCodes = new();
        private readonly ILog _log;

        public Scaner(ILog log)
        {
            _log = log;
        }

        public List<string> ScaneCodes { get => _scaneCodes; }

        public string ScanedCodes { get => string.Join("", _scaneCodes); }

        public void Scan(string productCode, Dictionary<string, IVolumePrice> prices)
        {
            if (prices is null)
            {
                _log.LogMessage($"{nameof(Scaner)}: Can't scan. There are no product code list loaded");
                return;
            }

            if (prices.ContainsKey(productCode))
            {
                _scaneCodes.Add(productCode);
            }
            else
            {
                _log.LogMessage($"{nameof(Scaner)}: Can't scan. Such type of product: {productCode} is unknown");
            }
        }
    }
}
