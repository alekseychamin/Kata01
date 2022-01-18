using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminalApi
{
    public static class CheckRange
    {
        public static bool IsValid(int? value)
        {
            return value.HasValue && value > 0;
        }

        public static bool IsValid(double? value)
        {
            return value.HasValue && value > 0;
        }

        public static bool IsValid(double value)
        {
            return value > 0;
        }
    }
}
