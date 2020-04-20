using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBot.Models
{
    /// <summary>
    /// Represents a stock, an investment instrument.
    /// Stocks represents the right to collect a part of the earnings of a Company.
    /// </summary>
    public class Stock
    {
    /*
    {
      "cantidad": 319.0000,
      "comprometido": 0.0000,
      "puntosVariacion": -7.25000000,
      "variacionDiaria": -5.93,
      "ultimoPrecio": 115.00000000,
      "ppc": 130.420,
      "gananciaPorcentaje": -11.82,
      "gananciaDinero": -4919.00,
      "valorizado": 36685.000000000000,
      "titulo": {
        "simbolo": "GGAL",
        "descripcion": "Grupo Financiero Galicia",
        "pais": "argentina",
        "mercado": "bcba",
        "tipo": "ACCIONES",
        "plazo": "t0",
        "moneda": "peso_Argentino"
      }
    },
    */

        // TODO: make these properties, not fields.
        public string ticker = string.Empty;    // titulo.simbolo
        public string company = string.Empty;   // titulo.descripcion
        public string market = string.Empty;    // titulo.mercado
        public float last_closing_price = 0;    // ultimoPrecio
        public float daily_variation = 0;       // variacionDiaria
        public string currency = "ARS";         // titulo.moneda
        public string country = "ar";           // titulo.pais

        public Stock()
        {
            ticker = string.Empty;
            company = string.Empty;
            market = Market.NASDAQ;
        }

        public Stock(string ticker)
        {
            this.ticker = ticker;
            market = Market.NASDAQ;
        }

        public string to_string()
        {
            return string.Format("{0} ({1})", ticker, company);
        }

        public double get_current_price()
        {
            // TODO: Logic to get the current price.
            // randomized for now, should simulate a connection with the Broker
            // a factory pattern can help if we want to make it capable of transacting with different Brokers

            //return round(random.uniform(Constants.min_variation, Constants.max_variation), Constants.max_decimals)
            Random random = new Random();
            float current_price = random.Next(Constants.min_variation, Constants.max_variation);
            return Math.Round(current_price, Constants.max_decimals);
        }
    }
}
