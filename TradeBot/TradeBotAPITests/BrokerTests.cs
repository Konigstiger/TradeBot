using System;
using TradeBotAPI.Models;
using TradeBotAPITests.Fakes;
using Xunit;

namespace TradeBotAPITests
{
    public class BrokerTests
    {
        IBroker _service;

        public BrokerTests()
        {
            //_service = new BrokerFake();
            _service = new Broker("IOL", 0.005);
        }


        [Fact]
        public void Get_WhenCalled_Returns_5()
        {
            // Act
            var okResult = _service.GetCommission();

            // Assert
            Assert.Equal(0.005, okResult);
        }


        [Fact]
        public void Test1()
        {
            
        }
    }
}
