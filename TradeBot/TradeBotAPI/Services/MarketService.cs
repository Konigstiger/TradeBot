using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TradeBotAPI.Models;
using TradeBotAPI.Models.IOL;


namespace TradeBotAPI.Services
{
    // INFO: This class needs to match, and , the methods from the real class.
    // Is better if the changes are also reflected in the IMarketService

    public class MarketService : IMarketService
    {
        public AccessTokenResponse BearerToken { get; set; }

        // TODO: Ver una forma de inyectar estas urls, o bien que esten en una propiedad.
        private const string urlToken = "https://api.invertironline.com/token";
        private const string baseUrl = "https://api.invertironline.com/api/v2/";
        private const string urlMarketReady = baseUrl + "Cotizaciones/acciones/Merval/argentina";

        //GET /api/v2/Cotizaciones/{Instrumento}/{Panel}/{Pais}

        // GET /api/v2/{Mercado}/Titulos/{Simbolo}/Cotizacion
        // parameters: mercado, simbolo, model.simbolo, model.mercado, model.plazo
        // Possible values: Mercado: bCBA, nYSE, nASDAQ, aMEX, bCS, rOFX
        // Possible values: Simbolo: GGAL, ALUA, APBR, ...
        // Possible values: model.plazo = t0, t1, t2
        // Possible values: Pais: argentina estados_Unidos

        private readonly HttpClient _client;

        public MarketService(HttpClient client)
        {
            _client = client;
        }

        private readonly IHttpClientFactory _clientFactory;

        public MarketService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        // DUPLICATED CODE FROM BrokerService
        private HttpClient HeadersForAccessTokenGenerate()
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = false };
            var client = new HttpClient(handler);
            try
            {
                var baseUrl = urlToken;
                client.BaseAddress = new Uri(baseUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return client;
        }

        // DUPLICATED CODE FROM BrokerService
        public async Task<AccessTokenResponse> GenerateAccessToken()
        {
            AccessTokenResponse token = null;
            // TODO: Hacer un extract de estos valores.
            string userName = "Konig";
            string password = "Overlord81";

            try
            {
                HttpClient client = HeadersForAccessTokenGenerate();
                string body = "grant_type=client_credentials";
                client.BaseAddress = new Uri(urlToken);
                var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                request.Content = new StringContent(body,
                                                    Encoding.UTF8,
                                                    "application/x-www-form-urlencoded");

                var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username", userName),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("grant_type", "password")
                };

                request.Content = new FormUrlEncodedContent(postData);
                HttpResponseMessage tokenResponse = client.PostAsync(urlToken, new FormUrlEncodedContent(postData)).Result;

                token = await tokenResponse.Content.ReadAsAsync<AccessTokenResponse>(new[] { new JsonMediaTypeFormatter() });

                // TODO: En caso de que token sea null, deberia loguear al menos o mostrar algun dato de tokenResponse antes que desaparezca.
            }

            catch (HttpRequestException ex)
            {
                throw ex;
            }
            return token ?? null;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<Market> GetMarketAsync()
        {
            // TODO: ver alguna forma de que esto sea permanente, y se use el token que corresponda, bearer o refresh.
            BearerToken = await GenerateAccessToken();

            if (null == BearerToken)
            {
                // TODO: Log this exception.
                throw new Exception("Cannot retrieve Market information: BearerToken not available.");
            }

            // antes de ejecutar la llamada normal, asociar el bearer token
            // TODO: Hacer alguna forma de asociar esto, que sea mas reusable.
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken.AccessToken);

            //var httpResponse = await _client.GetAsync($"{urlMarket}");
            var httpResponse = await _client.GetAsync($"{urlMarketReady}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve Market information.");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();

            //TODO: Ver si no hay que hacer un mapping acá de alguna forma.
            var item = JsonConvert.DeserializeObject<Market>(content);

            // TODO: ver que onda Ok.
            //var market = new Market();
            //market.PanelTituloModel = item;

            return item;
            //return market;
        }
    }
}
