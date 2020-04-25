using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TradeBotAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualStudio.Services.OAuth;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace TradeBotAPI.Services
{
    public class BrokerService : IBrokerService
    {
        public AccessTokenResponse BearerToken { get; set; }

        // TODO: Ver una forma de inyectar estas urls, o bien que esten en una propiedad.
        private const string urlToken = "https://api.invertironline.com/token";
        private const string urlPortfolio = "https://api.invertironline.com/api/v2/portafolio/argentina";

        // TODO: See if is better to use a HttpClientFactory instead. I think so.
        private readonly HttpClient _client;

        public BrokerService(HttpClient client)
        {
            _client = client;
        }

        private readonly IHttpClientFactory _clientFactory;

        public BrokerService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        private HttpClient HeadersForAccessTokenGenerate()
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = false };
            var client = new HttpClient(handler);
            try
            {
                var baseUrl = urlToken;
                client.BaseAddress = new Uri(baseUrl);

                // TODO: ver.
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                //client.DefaultRequestHeaders.Add("username", "Konig");
                //client.DefaultRequestHeaders.Add("password", "Overlord81");
                //client.DefaultRequestHeaders.Add("grant_type", "password");
                
                //// TEST: Ver si lo que hay arriba es necesario
                //client.DefaultRequestHeaders.Accept.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return client;
        }

        public async Task<AccessTokenResponse> GenerateAccessToken()
        {
            AccessTokenResponse token = null;

            try
            {
                HttpClient client = HeadersForAccessTokenGenerate();
                string body = "grant_type=client_credentials";
                client.BaseAddress = new Uri(urlToken);
                var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                request.Content = new StringContent(body,
                                                    Encoding.UTF8,
                                                    "application/x-www-form-urlencoded");

                var postData = new List<KeyValuePair<string, string>>();

                postData.Add(new KeyValuePair<string, string>("username", "Konig"));
                postData.Add(new KeyValuePair<string, string>("password", "Overlord81"));
                postData.Add(new KeyValuePair<string, string>("grant_type", "password"));

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


        public async Task<Portfolio> GetPortfolioAsync()
        {
            // TODO: ver alguna forma de que esto sea permanente, y se use el token que corresponda, bearer o refresh.
            BearerToken = await GenerateAccessToken();

            if (null == BearerToken)
            {
                throw new Exception("Cannot retrieve Portfolio: BearerToken not available.");
            }
            // antes de ejecutar la llamada normal, asociar el bearer token
            // TODO: Hacer alguna forma de asociar esto, que sea mas reusable.
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken.AccessToken);

            var httpResponse = await _client.GetAsync($"{urlPortfolio}");

            // NOTA: Acabo de darme cuenta que mas o menos con la linea de arriba y otra url,
            // puedo invocar basicamente toda la api!

            // urls:
            // [GET] /api/v2/estadocuenta
            // [GET] /api/v2/portafolio/{pais}
            // [GET] /api/v2/operaciones/{numero}



            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve Portfolio");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();

            //TODO: Ver si no hay que hacer un mapping acá de alguna forma.

            var item = JsonConvert.DeserializeObject<Portfolio>(content);

            return item;

        }


    }
}
