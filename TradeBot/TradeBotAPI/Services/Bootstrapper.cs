using Microsoft.Extensions.DependencyInjection;
using TradeBotAPI.Services.Fakes;
using TradeBotAPI.Services;

namespace TradeBotAPI.Services
{
    public static class Bootstrapper
    {
        /// <summary>
        /// Implemented services:
        /// <list type="bullet">
        ///     <item>BrokerService</item>
        ///     <item>MarketService</item></list>
        /// </summary>
        /// <param name="services"></param>
        public static void UseServices(this IServiceCollection services)
        {
            services.AddHttpClient<IBrokerService, BrokerService>();
            services.AddHttpClient<IMarketService, MarketService>();
        }

        /// <summary>
        /// Faked services:
        /// <list type="bullet">
        ///     <item>BrokerServiceFake</item>
        ///     <item>MarketServiceFake</item></list>
        /// </summary>
        /// <param name="services"></param>

        public static void UseFakeServices(this IServiceCollection services)
        {
            services.AddHttpClient<IBrokerService, BrokerServiceFake>();
            services.AddHttpClient<IMarketService, MarketServiceFake>();
        }

    }
}
