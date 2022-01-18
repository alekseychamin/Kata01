using PointOfSaleTerminalApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSaleTerminalApi.Models
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly ILog _log;

        public PriceCalculator(ILog log)
        {
            _log = log;
        }

        public double CalculateTotal(List<string> scaneCodes, Dictionary<string, IVolumePrice> prices)
        {
            double result = 0.0;

            var scanGroups = scaneCodes.GroupBy(x => x).Select(x => new { code = x.Key, count = x.Count() }).ToList();

            foreach (var item in scanGroups)
            {
                try
                {
                    result += prices[item.code].CalculatePrice(item.count);
                }
                catch (DivideByZeroException)
                {
                    _log.LogMessage($"{nameof(PriceCalculator)}: Divide by zero during calculation.");
                    throw;
                }
            }

            return result;
        }
    }
}
