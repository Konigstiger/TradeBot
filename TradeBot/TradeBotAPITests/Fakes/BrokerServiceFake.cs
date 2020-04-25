using System;
using System.Collections.Generic;
using System.Text;
using TradeBotAPI.Models;
using TradeBotAPI;
using TradeBotAPI.Services;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Services.OAuth;

namespace TradeBotAPITests.Fakes
{
    public class BrokerServiceFake : IBrokerService
    {
        public AccessTokenResponse BearerToken { get; set; }

        public async Task<Portfolio> GetPortfolioAsync()
        {
            throw new NotImplementedException();
        }
    }
}
