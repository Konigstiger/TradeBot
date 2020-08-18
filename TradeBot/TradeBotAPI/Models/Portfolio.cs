using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TradeBotAPI.Models.IOL;

namespace TradeBotAPI.Models
{
    /// <summary>
    /// Helps to admin the stocks holdings owned by the user.
    /// </summary>
    public class Portfolio
    {
        private readonly bool isEmpty;

        // TODO: CREATE INTERFACE TO IMPLEMENT. SOMETHING WITH USEFUL THINGS.

        public bool IsEmpty()
        {
            return (activos.Count == 0);
        }

        // TODO: See what about different currencies. ARS, USD.
        public double Cash_USD { get; set; }
        public double Cash_ARS { get; set; }

        public string pais { get; set; }

        public List<Activo> activos { get; set; }

        public List<Holding> StocksOwned { get; set; }

        public Portfolio()
        {
            StocksOwned = new List<Holding>();
            activos = new List<Activo>();
            // TODO: Estudiar alguna forma de mapear con operadores o algo util y fancy.
        }

        public string Show()
        {
            string result = string.Empty;

            // TODO: Remember to show how much free cash is there in the account.
            if (StocksOwned.Count == 0) return "Portfolio empty.";

            foreach (var holding in StocksOwned)
            {
                result += holding.ToString() + Constants.crlf;
            }
            return result;
        }



    }
}
