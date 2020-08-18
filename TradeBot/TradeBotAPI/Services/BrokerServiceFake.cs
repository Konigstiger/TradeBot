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
    // Is better if the changes are also reflected in the IBrokerService

    public class BrokerServiceFake : IBrokerService
    {
        public AccessTokenResponse BearerToken { get; set; }

        private readonly HttpClient _client;

        public BrokerServiceFake(HttpClient client)
        {
            _client = client;
        }

        private readonly IHttpClientFactory _clientFactory;

        public BrokerServiceFake(IHttpClientFactory clientFactory)
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
        // TODO: Add more possible responses.
        public async Task<Portfolio> Get()
        {
            // TODO: add more variety: use random values
            var result = new Portfolio();
            var activo1 = new Activo();
            var activo2 = new Activo();
            var activo3 = new Activo();
            
            activo1.cantidad = 20;
            activo1.variacionDiaria = -2;
            activo1.gananciaDinero = -25000;
            activo1.gananciaPorcentaje = -8.75F;
            activo1.ppc = 50F;
            activo1.ultimoPrecio = 40;
            activo1.valorizado = 500;
            activo1.titulo = new TituloModel("GGAL", "Grupo Financiero Galicia");

            activo2.cantidad = 25;
            activo2.variacionDiaria = 2.5F;
            activo2.gananciaDinero = 1003;
            activo2.gananciaPorcentaje = 10.25F;
            activo2.ppc = 30F;
            activo2.ultimoPrecio = 40F;
            activo2.valorizado = 5000;
            activo2.titulo = new TituloModel("MSFT", "Microsoft", "dolar_Estadounidense");

            activo3.cantidad = 42;
            activo3.variacionDiaria = 3.25F;
            activo3.gananciaDinero = 720F;
            activo3.gananciaPorcentaje = 12.5F;
            activo3.ppc = 25F;
            activo3.ultimoPrecio = 30F;
            activo3.valorizado = 500;
            activo3.titulo = new TituloModel("CEPU", "Central Puerto");

            result.activos.Add(activo1);
            result.activos.Add(activo2);
            result.activos.Add(activo3);

            return result;
        }


    }
}
