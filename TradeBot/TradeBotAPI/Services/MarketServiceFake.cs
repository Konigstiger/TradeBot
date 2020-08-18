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
        public async Task<Market> GetMarketAsync([FromBody] string countryCode)
        {
            var result = new Market();

            var titulo1 = new PanelTituloModel()
            {
            apertura = 94,
            cantidadOperaciones = 5411,
            fecha = "2020-05-11T17:00:06.153",
            fechaVencimiento = null,
            maximo = 105.1F,
            mercado = "BCBA",
            minimo = 90.05F,
            moneda = "ARS",
            precioEjercicio = null,
            puntas = new PuntasModel(200, 91F, 300, 104.25F),
            simbolo = "GGAL",
            tipoOpcion = null,
            ultimoCierre = 104.8F,
            ultimoPrecio = 104.8F,
            variacionPorcentual = 11.02F,
            volumen = 3104167
            };

            //TODO: Add PuntasModel

            
            var titulo2 = new PanelTituloModel()
            {
                apertura = 29,
                cantidadOperaciones = 1232,
                fecha = "2020-05-11T17:00:06.153",
                fechaVencimiento = null,
                maximo = 29.8F,
                mercado = "BCBA",
                minimo = 26.55F,
                moneda = "ARS",
                precioEjercicio = null,
                puntas = new PuntasModel(100, 26.75F, 200, 29F),
                simbolo = "CEPU",
                tipoOpcion = null,
                ultimoCierre = 29.2F,
                ultimoPrecio = 29.2F,
                variacionPorcentual = 2.46F,
                volumen = 917215
            };
            //TODO: Add PuntasModel

            result.titulos.Add(titulo1);
            result.titulos.Add(titulo2);

            return result;
        }
    }
}
