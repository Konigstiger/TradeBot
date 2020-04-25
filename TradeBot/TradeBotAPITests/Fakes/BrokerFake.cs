using System;
using System.Collections.Generic;
using System.Text;
using TradeBotAPI.Models;
using TradeBotAPI;

namespace TradeBotAPITests.Fakes
{
    public class BrokerFake : IBroker
    {
        public double GetCommission()
        {
            throw new NotImplementedException();
        }

        public void SetCommission(double value)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public void SetName(string value)
        {
            throw new NotImplementedException();
        }
    }
}
