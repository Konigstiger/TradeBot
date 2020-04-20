using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBot.Models
{
    /// <summary>
    /// Represents a buy or sale operation.
    /// </summary>
    public class Operation
    {
        public Stock Stock  { get; set; }
        public string type { get; set; }

        public bool Buy;

        public bool Sell;

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Amount { get; set; }

        /// <summary>
        /// The tax is the same everywhere (in a country)
        /// </summary>
        public float Tax { get; set; }

        /// <summary>
        /// The commission depends on the Broker.
        /// </summary>
        public float Commission { get; set; }

        public DateTime TimeStamp { get; set; }

        public OperationStatus Status { get; set; }

        public Operation()
        {
            Buy = false;
            Sell = false;
            Quantity = 0;
            Price = 0;
            Amount = 0;
            Stock = new Stock();
            TimeStamp = DateTime.Now;
            Status = OperationStatus.Pending;
            Tax = 0;
            Commission = 0;
        }



    }
}
