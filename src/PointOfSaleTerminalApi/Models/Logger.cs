using PointOfSaleTerminalApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminalApi.Models
{
    public class Logger : ILog
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
