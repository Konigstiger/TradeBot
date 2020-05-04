using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.OAuth;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TradeBotAPI.Models;
using TradeBotAPI.Models.IOL;


namespace TradeBotAPI.Services.Fakes
{
    // INFO: This class needs to match, and fake, the methods from the real class.
    // Is better if the changes are also reflected in the IMarketService

    public class MarketServiceFake : IMarketService
    {
        public AccessTokenResponse BearerToken { get; set; }

        private readonly HttpClient _client;

        public MarketServiceFake(HttpClient client)
        {
            _client = client;
        }

        private readonly IHttpClientFactory _clientFactory;

        public MarketServiceFake(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public Task<AccessTokenResponse> GenerateAccessToken()
        {
            // TODO: I dont know if this can be faked or avoided.
            throw new NotImplementedException();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<Market> GetMarketAsync()
        {
            var result = new Market();

            var stock1 = new Stock
            {
                company = "Microsoft Corporation",
                ticker = "MSFT"
            };
            // TODO: Complete models and add more properties.

            var stock2 = new Stock
            {
                company = "Grupo Financiero Galicia",
                ticker = "GGAL"
            };

            var stock3 = new Stock
            {
                company = "Central Puerto",
                ticker = "CEPU"
            };

            result.Stocks.Add(stock1);
            result.Stocks.Add(stock2);
            result.Stocks.Add(stock3);
            
            return result;
        }
    }
}
