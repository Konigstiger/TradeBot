using Microsoft.VisualStudio.Services.OAuth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeBotAPI.Models;

namespace TradeBotAPI.Services
{
    public interface IBrokerService
    {
        public AccessTokenResponse BearerToken { get; set; }

        public Task<Portfolio> Get();

        public Task<AccessTokenResponse> GenerateAccessToken();

    }
}