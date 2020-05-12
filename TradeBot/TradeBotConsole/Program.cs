using Microsoft.Extensions.DependencyInjection;
using System;
using TradeBotAPI.Services;
using TradeBotAPI.Models;
using TradeBotConsole.Colors;
using TradeBotAPI.Controllers;

namespace TradeBotConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            EscapeSequencer.Install();
            EscapeSequencer.Bold = true; //set default bold to On. Actually this will use bright colors. Easier to read
            Console.WriteLine("");

            ShowIntro();

            bool showFake = false;

            bool showPortfolio = false;
            bool showMarket = false;

            if (args.Length > 0)
            {
                // rudimentary 'parsing': first pass
                foreach (var item in args)
                {
                    if (item.Trim().ToLower().Equals("portfolio"))
                    {
                        showPortfolio = true;
                    }
                    else if (item == "-fake" || item == "--fake")
                    {
                        showFake = true;
                    }
                    else if (item.Trim().ToLower().Equals("market"))
                    {
                        showMarket = true;
                    }
                }

                var services = new ServiceCollection();

                if (showFake)
                {
                    services.UseFakeServices();
                }
                else
                {
                    services.UseServices();
                }

                var serviceProvider = services.BuildServiceProvider();
                var servicePortfolio = serviceProvider.GetRequiredService<IBrokerService>();
                var serviceMarket = serviceProvider.GetRequiredService<IMarketService>();

                if (showPortfolio)
                {
                    var portfolio = PortfolioController.GetPortfolio(servicePortfolio).Result;
                    ShowPortfolioToScreen(portfolio);
                }
                else if (showMarket) { 
                    ShowMarket("ar");

                    var market = MarketController.GetMarketAsync(serviceMarket).Result;
                    ShowMarketToScreen(market);
                }
                else
                {
                    Ccw("Nothing to see here.", ConsoleColor.Cyan, true);
                    ShowExit();
                    // Console.ReadKey();
                }

            }
            ShowTimestamp();
        }

        private static void ShowMarket(string marketName)
        {
            Ccw("Market: " + marketName, ConsoleColor.Yellow, true);
            
            // TODO: here we invoke our web API.

        }

        private static void ShowTimestamp()
        {
            Ccw("Last update: ", ConsoleColor.Gray);
            Ccw(DateTime.Now.ToString(), ConsoleColor.DarkGray, true);
        }

        private static void ShowExit()
        {
            Ccw("Disconnected.", ConsoleColor.DarkRed, true);
        }

        private static void ShowPortfolioToScreen(Portfolio portfolio)
        {
            int w = 120;

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


            foreach (var item in portfolio.activos)
            {
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
            CLine(w);
        }


        private static void ShowMarketToScreen(Market market)
        {
            int w = 120;

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

            foreach (var item in market.titulos) {
                // IOL has these columns of data:
                //Simbolo | Ultimo Operado | Variacion Diaria || Cantidad Compra | Pr Compra | Cantidad Venta  |Pr Venta || 
                //Apertura | Minimo | Maximo | Ultimo Cierre | Monto Operado | Fecha/Hora

                //Ticker | Last Price $ | Variacion Diaria % || Cantidad Compra | Pr Compra | Cantidad Venta  |Pr Venta || 
                //Apertura $ | Minimo $ | Maximo $ | Ultimo Cierre $ | Monto Operado $ | Fecha/Hora

                var moneySymbol = TranslateMoneyDescription(item.moneda);
                var text = String.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} |",
                        item.simbolo.PadRight(9, ' ').Blue(),
                        item.ultimoPrecio.ToString().PadLeft(9, ' ').Yellow(),
                        (item.variacionPorcentual.ToString().Trim() + " %").PadLeft(10, ' ').ConditionalNumber(),
                        item.apertura.ToString().PadLeft(10, ' '),
                        item.minimo.ToString().PadLeft(12, ' ').Yellow(),
                        item.maximo.ToString().PadLeft(12, ' ').Yellow(),
                        item.ultimoCierre.ToString().PadLeft(12, ' ').Yellow()
                        );

                Console.WriteLine(text);

                /*
                var moneySymbol = TranslateMoneyDescription(item.titulo.moneda);
                var text = String.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6}",
                        item.cantidad.ToString().PadLeft(8, ' ').Yellow(),
                        item.titulo.simbolo.PadRight(9, ' ').Blue(),
                        item.titulo.descripcion.PadRight(30, ' '),
                        (item.variacionDiaria.ToString().Trim() + " %").PadLeft(10, ' ').ConditionalNumber(),
                        (item.gananciaPorcentaje.ToString().Trim() + " %").PadLeft(10, ' ').ConditionalNumber(),
                        (moneySymbol + item.gananciaDinero.ToString().PadLeft(10, ' ').PadRight(10, ' ')).ConditionalNumber(),
                        (moneySymbol + item.valorizado.ToString().PadLeft(12, ' ')).Grey()
                        );

                Console.WriteLine(text);
                */
            }

        }


        private static string TranslateMoneyDescription(string value)
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
        /// Introduction.
        /// </summary>
        private static void ShowIntro()
        {
            Ccw("Welcome to ", ConsoleColor.Cyan);
            Ccw("TradeBot Console", ConsoleColor.DarkCyan, true);

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


    }
}
