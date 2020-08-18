using Microsoft.Extensions.DependencyInjection;
using System;
using TradeBotAPI.Services;
using TradeBotAPI.Models;
using TradeBotConsole.Colors;
using TradeBotAPI.Controllers;
using Microsoft.VisualStudio.Services.Common;

namespace TradeBotConsole
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
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
                BrokerService servicePortfolio = (BrokerService) serviceProvider.GetRequiredService<IBrokerService>();
                MarketService serviceMarket = (MarketService) serviceProvider.GetRequiredService<IMarketService>();

                if (showPortfolio)
                {
                    var localPortfolioController = new PortfolioController(servicePortfolio);
                    var portfolio = await localPortfolioController.Get();
                    Utilities.ShowPortfolioToScreen(portfolio.Value);
                }
                else if (showMarket) 
                { 
                    var localMarketController = new MarketController(serviceMarket);
                    var market = localMarketController.Get("ar").Result;
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
