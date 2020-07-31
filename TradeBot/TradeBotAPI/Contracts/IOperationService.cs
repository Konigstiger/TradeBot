using Microsoft.VisualStudio.Services.OAuth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeBotAPI.Models;

namespace TradeBotAPI.Services
{
    public interface IOperationService
    {
        public AccessTokenResponse BearerToken { get; set; }

        public Task<Operation> GetOperationAsync();

        public Task<AccessTokenResponse> GenerateAccessToken();

    }
}