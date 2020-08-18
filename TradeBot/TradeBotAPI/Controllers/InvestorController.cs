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
    public class InvestorController : ControllerBase
    {
        /*
        GET: read existing data
        POST: create new data
        PUT: update existing data
        PATCH: update a subset of existing data
        DELETE: remove existing data         
        */

        private readonly IBrokerService service;
        private readonly ILogger<InvestorController> logger;
        private readonly IConfiguration configuration;

        public InvestorController(
            IBrokerService service,
            ILogger<InvestorController> logger, IConfiguration configuration)
        {
            this.service = service;
            this.logger = logger;
            this.configuration = configuration;
        }


        //// GET: api/Investor
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public static async Task<ActionResult<Investor>> GetInvestor(IBrokerService service)
        //{
        //    //var result = await service.GetInvestorAsync();
        //    //return result;
        //    throw new NotImplementedException();
        //}


        //// GET: api/Investor/5
        //[HttpGet("{id}", Name = "Get")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Investor
        [HttpPost]
        public void Post([FromBody] Person value)
        {
        }

        // PUT: api/Investor/5
        [HttpPut("{id}")]
        public Person Put([FromBody] Person newInvestor)
        {
            // this should trigger
            return newInvestor;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
