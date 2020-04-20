using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBot.Models
{
    /// <summary>
    /// Contains details about the stocks owned by the user. 
    /// A holding is an executed buy operation.
    /// </summary>
    public class Holding
    {
        public Stock Stock { get; set; }

        public int Quantity { get; set; }

        public int QuantityCompromised { get; set; }

        public double DailyVariation { get; set; }

        public double LastPrice { get; set; }

        public double AveragePrice { get; set; }

        public Holding()
        {
            Stock = new Stock();
            DailyVariation = Stock.get_current_price();
            LastPrice = 150;
            AveragePrice = 140;
            Quantity = 0;
            QuantityCompromised = 0;
        }

        /// <summary>
        /// Returns a text representation of the object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}\t{2}\t{3}\t{4}\t{5}", 
                Stock.ticker, Stock.company, Quantity, DailyVariation, LastPrice, AveragePrice);
        }
    }
}
