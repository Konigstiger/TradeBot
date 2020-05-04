using Microsoft.VisualStudio.Services.OAuth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeBotAPI.Models;

namespace TradeBotAPI.Services
{
    public interface IMarketService
    {
        public AccessTokenResponse BearerToken { get; set; }

        public Task<Market> GetMarketAsync();

        public Task<AccessTokenResponse> GenerateAccessToken();

    }
}