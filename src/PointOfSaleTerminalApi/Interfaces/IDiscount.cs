using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminalApi.Interfaces
{
    public interface IDiscount
    {
        int Volume { get; set; }

        double Price { get; set; }
    }
}
