using System;
using System.Collections.Generic;
using System.Text;
using TradeBotAPI.Models;
using TradeBotConsole.Colors;

namespace TradeBotConsole
{
    class Utilities
    {
        public static string TranslateMoneyDescription(string value)
        {
            if ("peso_Argentino" == value)
            {
                return "AR$ ";
            }
            if ("dolar_Estadounidense" == value)
            {
                return "U$D ";
            }
            return value;
        }

        /// <summary>
        /// Console Color Write.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void Ccw(string text, ConsoleColor color, bool newLine = false)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            if (newLine) { Console.WriteLine(text); } else { Console.Write(text); }
            Console.ForegroundColor = originalColor;
        }


        /// <summary>
        /// Creates an horizontal line with dashes
        /// --------------------------------------
        /// </summary>
        /// <param name="columnWidth"></param>
        public static void CLine(int columnWidth)
        {
            Console.WriteLine("-".PadLeft(columnWidth, '-'));
        }

        public static void ShowTimestamp()
        {
            Ccw("Last update: ", ConsoleColor.Gray);
            Ccw(DateTime.Now.ToString(), ConsoleColor.DarkGray, true);
        }
        public static void ShowExit()
        {
            Ccw("Disconnected.", ConsoleColor.DarkRed, true);
        }

        public static void ShowMarket(string marketName)
        {
            Ccw("Market: " + marketName, ConsoleColor.Yellow, true);

            // TODO: here we invoke our web API.

        }

        /// <summary>
        /// Introduction.
        /// </summary>
        public static void ShowIntro()
        {
            Utilities.Ccw("Welcome to ", ConsoleColor.Cyan);
            Utilities.Ccw("TradeBot Console", ConsoleColor.DarkCyan, true);

            // Standard Color reference:
            // =========================
            // DarkGray: Ideal for disabled items, or inactive things.
            // Black
            // DarkBlue
            // DarkGreen
            // DarkCyan: Great for titles or program name, or status.
            // DarkRed
            // DarkMagenta
            // DarkYellow
            // Gray
            // DarkGray
            // Blue
            // Green
            // Cyan
            // Red
            // Magenta
            // Yellow
            // White
        }

        public static void ShowPortfolioToScreen(Portfolio portfolio)
        {
            int w = 118;

            // TODO: see how to calculate the dashes to fix.
            CLine(w);
            Console.WriteLine(String.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6}",
                    "Quantity".PadLeft(8, ' '),
                    "Ticker".PadRight(9, ' '),
                    "Description".PadRight(30, ' '),
                    "Day Var. %".PadLeft(10, ' '),
                    "Earnings %".PadLeft(10, ' '),
                    "Earnings $".PadLeft(14, ' '),
                    "Valued   $".PadLeft(12, ' ')
                    )
                );
            CLine(w);

            if (portfolio.activos != null)
            {
                foreach (var item in portfolio.activos)
                {
                    if (item.titulo.descripcion.Length >= 30)
                    {
                        item.titulo.descripcion = item.titulo.descripcion.Substring(0, 30);
                    }

                    var moneySymbol = TranslateMoneyDescription(item.titulo.moneda);
                    var text = String.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6}",
                            item.cantidad.ToString().PadLeft(8, ' ').Yellow(),
                            item.titulo.simbolo.PadRight(9, ' ').Blue(),
                            item.titulo.descripcion.PadRight(30, ' '),
                            (item.variacionDiaria.ToString().Trim() + " %").PadLeft(10, ' ').ConditionalNumber(),
                            (item.gananciaPorcentaje.ToString().Trim() + " %").PadLeft(10, ' ').ConditionalNumber(),
                            (moneySymbol + item.gananciaDinero.ToString().PadLeft(10, ' ').PadRight(10, ' ')).ConditionalNumber(),
                            (moneySymbol + item.valorizado.ToString().PadLeft(12, ' ')).ConditionalNumber()
                            );

                    Console.WriteLine(text);

                    // NOTE: using ToString("C") gives the currency format defined in the pc. Useful. Parametrize!
                    // TODO: Objetivo: Poder escribir a color, a nivel de CELDA, no de fila.
                }
            }
            CLine(w);
        }


        public static void ShowMarketToScreen(Market market)
        {
            int w = 118;

            CLine(w);
            Ccw("Found " + market.titulos.Count + " stocks.", ConsoleColor.Green, true);
            CLine(w);
            //Ticker | Last Price $ | Variacion Diaria % || Cantidad Compra | Pr Compra | Cantidad Venta  |Pr Venta || 
            //Apertura $ | Minimo $ | Maximo $ | Ultimo Cierre $ | Monto Operado $ | Fecha/Hora
            Console.WriteLine(String.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} |",
                    "Symbol  ".PadLeft(9, ' '),
                    "Curr $".PadRight(9, ' '),
                    "Day Var. %".PadLeft(10, ' '),
                    "Open $".PadLeft(10, ' '),
                    "Min $".PadLeft(12, ' '),
                    "Max $".PadLeft(12, ' '),
                    "Last Close $".PadLeft(12, ' ')
                    )
                );
            CLine(w);

            foreach (var item in market.titulos)
            {
                // IOL has these columns of data:
                //Simbolo | Ultimo Operado | Variacion Diaria || Cantidad Compra | Pr Compra | Cantidad Venta  |Pr Venta || 
                //Apertura | Minimo | Maximo | Ultimo Cierre | Monto Operado | Fecha/Hora

                //Ticker | Last Price $ | Variacion Diaria % || Cantidad Compra | Pr Compra | Cantidad Venta  |Pr Venta || 
                //Apertura $ | Minimo $ | Maximo $ | Ultimo Cierre $ | Monto Operado $ | Fecha/Hora

                var moneySymbol = Utilities.TranslateMoneyDescription(item.moneda);
                var text = String.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} |",
                        item.simbolo.PadRight(9, ' ').Blue(),
                        item.ultimoPrecio.ToString().PadLeft(9, ' ').Yellow(),
                        (item.variacionPorcentual.ToString().Trim() + " %").PadLeft(10, ' ').ConditionalNumber(),
                        (moneySymbol + item.apertura.ToString().PadLeft(10, ' ')).Yellow(),
                        (moneySymbol + item.minimo.ToString().PadLeft(12, ' ')).Yellow(),
                        (moneySymbol + item.maximo.ToString().PadLeft(12, ' ')).Yellow(),
                        (moneySymbol + item.ultimoCierre.ToString().PadLeft(12, ' ')).Yellow()
                        );

                Console.WriteLine(text);

            }

        }
    }
}
