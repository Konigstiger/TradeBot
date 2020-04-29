using Microsoft.Extensions.DependencyInjection;
using TradeBotAPI.Services.Fakes;

namespace TradeBotAPI.Services
{
    public static class Bootstrapper
    {
        public static void UseServices(this IServiceCollection services)
        {
            services.AddHttpClient<IBrokerService, BrokerService>();
        }

        // this can be handy, my ideas
        public static void UseFakeServices(this IServiceCollection services)
        {
            services.AddHttpClient<IBrokerService, BrokerServiceFake>();
        }

    }
}
