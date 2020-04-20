using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBot.Models
{
    /// <summary>
    /// Represents an intermediary that executes buy and sell orders, among other tasks.
    /// </summary>
    public class Broker
    {
        public string Name { get; set; }
        public double Commission { get; set; }

        public Broker()
        {
            Name = "Fast Broker";
            Commission = 0.005;
        }
    }
}
