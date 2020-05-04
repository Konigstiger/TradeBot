using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBotAPI.Models
{
    /// <summary>
    /// This class contains information about the available formal markets where stock trading is enabled
    /// </summary>
    public class Market
    {
        public static string NASDAQ = "National Association of Securities Dealers Automated Quotation";
        public static string NYSE = "New York Security Exchange";
        public static string BCBA = "Bolsa de Comercio de Buenos Aires";

        // TODO: See if this class (owned) is enough.
        public List<Stock> Stocks { get; set; }

        public Market()
        {
            Stocks = new List<Stock>();
        }


    }
}
