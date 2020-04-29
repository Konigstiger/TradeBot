using Microsoft.Extensions.DependencyInjection;
using System;
using TradeBotAPI.Services;
using TradeBotAPI.Models;
using TradeBotAPI.Models.IOL;
using TradeBotAPI.ExtensionMethods;
using TradeBotConsole.Colors;
using TradeBotAPI.ExtensionMethods;

namespace TradeBotConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            EscapeSequencer.Install();
            EscapeSequencer.Bold = true; //set default bold to On. Actually this will use bright colors. Easier to read
            Console.WriteLine("");
            //Console.WriteLine("INFO: ".Red().Bold() + "Welcome ".Red() + ", " + "Motherfuckers.".Rainbow());

            ShowIntro();

            bool showFake = false;
            bool showPortfolio = false;

            if (args.Length > 0)
            {
                // rudimentary 'parsing'
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
                }

                if (showPortfolio)
                {
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
                    var service = serviceProvider.GetRequiredService<IBrokerService>();
                    Portfolio portfolio = GetPortFolioAsync(service);

                    ShowPortfolioToScreen(portfolio);
                }
                else
                {
                    Console.WriteLine("Nothing to see here.");
                    ShowExit();
                    // Console.ReadKey();
                }
            }
        }

        private static Portfolio GetPortFolioAsync(IBrokerService service)
        {
            return service.GetPortfolioAsync().Result;
        }

        private static void ShowExit()
        {
            var originalForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Disconnected.");
            Console.ForegroundColor = originalForegroundColor;
        }

        private static void ShowPortfolioToScreen(Portfolio portfolio)
        {
            int w = 100;

            // TODO: see how to calculate the dashes to fix.
            CLine(w);
            Console.WriteLine(String.Format("{0} | {1} | {2} | {3} | {4} | {5}",
                    "Quantity".PadLeft(8, ' '),
                    "Ticker".PadRight(10, ' '),
                    "Description".PadRight(30, ' '),
                    "Day Var. %".PadLeft(10, ' '),
                    "Earnings %".PadLeft(10, ' '),
                    "Earnings $".PadLeft(10, ' '))
                    );
            CLine(w);

            // TODO: ADD DAILY PROGRESS

            foreach (var item in portfolio.activos)
            {
                var text = String.Format("{0} | {1} | {2} | {3} | {4} | {5}",
                        item.cantidad.ToString().PadLeft(8, ' ').Yellow(),
                        item.titulo.simbolo.PadRight(10, ' ').Blue(),
                        item.titulo.descripcion.PadRight(30, ' '),
                        (item.variacionDiaria.ToString().Trim() + " %") .PadLeft(10, ' ').ConditionalNumber(),
                        (item.gananciaPorcentaje.ToString().Trim() + " %").PadLeft(10, ' ').ConditionalNumber(),
                        ((TranslateMoneyDescription(item.titulo.moneda) + (item.gananciaDinero.ToString().PadLeft(10, ' ')).PadRight(10, ' ')).ConditionalNumber()
                        ));

                Console.WriteLine(text);
                
                // NOTE: using ToString("C") gives the currency format defined in the pc. Useful. Parametrize!
                // TODO: Objetivo: Poder escribir a color, a nivel de CELDA, no de fila.
            }
            CLine(w);
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
            Ccw("Welcome to ", ConsoleColor.Yellow);
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
