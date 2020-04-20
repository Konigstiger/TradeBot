using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBot.Models
{
    /// <summary>
    /// Helps to admin the stocks holdings owned by the user.
    /// </summary>
    public class Portfolio
    {
        // TODO: See what about different currencies. ARS, USD.
        public double Cash_USD { get; set; }
        public double Cash_ARS { get; set; }

        public List<Holding> StocksOwned { get; set; }

        public Portfolio()
        {
            StocksOwned = new List<Holding>();
            // TODO: Activate this method: read_json_data_from_file() 
            // read_json_data_from_file();
        }

        public string Show()
        {
            string result = string.Empty;

            // TODO: Remember to show how much free cash is there in the account.
            if (StocksOwned.Count == 0) return "Portfolio empty.";

            // print headers first
            // this.PrintHeaders();

            foreach (var holding in StocksOwned)
            {
                result += holding.ToString() + Constants.crlf;
            }
            return result;
        }



    }
}
