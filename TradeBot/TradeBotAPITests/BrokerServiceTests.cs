using Microsoft.Extensions.DependencyInjection;
using System;
using TradeBotAPI.Models;
using TradeBotAPI.Services;
using TradeBotAPITests.Fakes;
using Xunit;

namespace TradeBotAPITests
{
    public class BrokerServiceTests
    {
        IBrokerService _service;

        [Fact]
        public void WhenPortfolioIsRequested_Return_Not_Null()
        {
            //_service = new BrokerServiceFake();
           // _service = new BrokerService("IOL", 0.005);
            // Arrange
            var services = new ServiceCollection();
            //services.UseServices();
            services.UseFakeServices();     // TEST: this will make it go through the Fake version.
            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<IBrokerService>();

            // Act
            var porty = service.Get();

            // Assert
            Assert.NotNull(porty.Result);
        }




    }
}
