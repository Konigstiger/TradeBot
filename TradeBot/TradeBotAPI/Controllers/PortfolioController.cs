using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TradeBotAPI.Config;
using TradeBotAPI.Models;
using TradeBotAPI.Services;

namespace TradeBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IBrokerService service;
        private readonly ILogger<PortfolioController> logger;
        private readonly IConfiguration configuration;

        public PortfolioController(
            IBrokerService service,
            ILogger<PortfolioController> logger, IConfiguration configuration)
        {
            this.service = service;
            this.logger = logger;
            this.configuration = configuration;
        }


        // GET: api/Portfolio
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public static async Task<ActionResult<Portfolio>> GetPortfolio(IBrokerService service)
        {
            var result = await service.GetPortfolioAsync();
            return result;
        }


        // GET: api/Portfolio/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Portfolio
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Portfolio/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
