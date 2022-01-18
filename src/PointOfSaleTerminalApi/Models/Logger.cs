using PointOfSaleTerminalApi.Interfaces;
using System;

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
