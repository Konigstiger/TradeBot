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

            Utilities.ShowIntro();

            bool showFake = false;

            bool showPortfolio = false;
            bool showMarket = false;
            bool buyOperation = false;
            bool sellOperation = false;

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
                    else if (item.Trim().ToLower().Equals("buy"))
                    {
                        buyOperation = true;
                    }
                    else if (item.Trim().ToLower().Equals("sell"))
                    {
                        sellOperation = true;
                    }
                    // TODO: Add an option to recognize buy and sell verbs.
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
                    Utilities.ShowPortfolioToScreen(portfolio.Value);
                }
                else if (showMarket) { 
                    Utilities.ShowMarket("ar");

                    var market = MarketController.GetMarketAsync(serviceMarket).Result;
                    Utilities.ShowMarketToScreen(market);
                }
                else if (buyOperation)
                { 
                    // BOB do something! 
                }
                else if (sellOperation)
                {
                    // BOB do something! 
                }
                else
                {
                    Utilities.Ccw("Nothing to see here.", ConsoleColor.Cyan, true);
                    Utilities.ShowExit();
                    // Console.ReadKey();
                }

            }
            Utilities.ShowTimestamp();
        }

    }
}
