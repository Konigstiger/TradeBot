using Microsoft.Extensions.DependencyInjection;

namespace TradeBotAPI.Services
{
    public static class Bootstrapper
    {
        public static void UseServices(this IServiceCollection services)
        {
            services.AddHttpClient<IBrokerService, BrokerService>();
        }
    }
}
