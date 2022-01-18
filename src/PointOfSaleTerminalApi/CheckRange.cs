using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminalApi
{
    public static class CheckRange
    {
        public static bool IsValid<T>(T value) where T : struct, IComparable<T>
        {
            return (value.CompareTo(default(T)) > 0);
        }

        public static void 
    }
}
