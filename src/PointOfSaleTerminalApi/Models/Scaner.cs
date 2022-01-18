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

        public string ScanedCodes { get => string.Join("", ScaningCodes); }

        public void Scan(string productCode, Dictionary<string, IVolumePrice> prices)
        {
            if (prices is null)
            {
                _log.LogMessage($"{nameof(Scaner)}: Can't scan. There are no product code list loaded");
                return;
            }

            if (prices.ContainsKey(productCode))
            {
                ScaningCodes.Add(productCode);
            }
            else
            {
                _log.LogMessage($"{nameof(Scaner)}: Can't scan. Such type of product: {productCode} is unknown");
            }
        }
    }
}
