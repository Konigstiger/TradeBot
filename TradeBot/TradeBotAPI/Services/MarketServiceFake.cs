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

            var titulo1 = new PanelTituloModel()
            {
                apertura = 10F,
                cantidadOperaciones = 5,
                simbolo = "GGAL",
                ultimoPrecio = 25F,
                maximo = 12F,
                minimo = 10F,
                volumen = 500F,
                fecha = DateTime.Now.ToString(),
                ultimoCierre = 10F,
                mercado = "bcba"
            };

            /*
             GGAL
            apertura: 94
            cantidadOperaciones: 5411
            fecha: "2020-05-11T17:00:06.153"
            fechaVencimiento: null
            maximo: 105.1
            mercado: "BCBA"
            minimo: 90.05
            moneda: "ARS"
            precioEjercicio: null
            puntas: PuntasModel
            simbolo: "GGAL"
            tipoOpcion: null
            ultimoCierre: 104.8
            ultimoPrecio: 104.8
            variacionPorcentual: 11.02
            volumen: 3104167 (ver en millones o en miles, lo mas pequeño)



            CEPU
            apertura: 29
            cantidadOperaciones: 1232
            fecha: "2020-05-11T17:00:06.153"
            fechaVencimiento: null
            maximo: 29.8
            mercado: "BCBA"
            minimo: 26.55
            moneda: "ARS"
            precioEjercicio: null
            puntas: PuntasModel
            simbolo: "CEPU"
            tipoOpcion: null
            ultimoCierre: 29.2
            ultimoPrecio: 29.2
            variacionPorcentual: 2.46 
            volumen: 917215
             */

            result.titulos.Add(titulo1);

            return result;
        }
    }
}
