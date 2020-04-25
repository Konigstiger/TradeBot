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
        public void Test_crap()
        {
            //_service = new BrokerServiceFake();
           // _service = new BrokerService("IOL", 0.005);

            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IBrokerService>();

            var porty = service.GetPortfolioAsync();

            Assert.NotNull(porty.Result);
        }


        [Fact]
        public void Token_WhenCalled_Returns_Not_Null()
        {
            // Arrange
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<IBrokerService>();

            // Act
            var okResult = _service.BearerToken;

            // Assert
            Assert.NotNull(okResult);
        }


    }
}
