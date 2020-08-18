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
        /*
        GET: read existing data
        POST: create new data
        PUT: update existing data
        PATCH: update a subset of existing data
        DELETE: remove existing data
        */

        private readonly IBrokerService service;
        private readonly ILogger<PortfolioController> logger;
        private readonly IConfiguration configuration;

        //public PortfolioController(
        //    IBrokerService service,
        //    ILogger<PortfolioController> logger, IConfiguration configuration)
        //{
        //    this.service = service;
        //    this.logger = logger;
        //    this.configuration = configuration;
        //}

        public PortfolioController(IBrokerService service)
        {
            this.service = service;
        }

        // GET: api/Portfolio
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Portfolio>> Get()
        {
            var result = await service.Get();
            return Ok(result);
        }


        //// GET: api/Portfolio/5
        //[HttpGet("{id}", Name = "Get")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Portfolio
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Portfolio/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        /*
        [HttpPost]
        [Route("join")]
        public async Task<ActionResult<CallModel>> JoinCallAsync([FromBody] JoinCallBody joinCallBody)
        {
            var call = await this.callsService.JoinCallAsync(joinCallBody);
            return this.Ok(call);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CallModel>> GetAsync([FromRoute] string id, [FromQuery] bool archive)
        {
            var call = await this.callsService.GetCallAsync(id, archive);
            return this.Ok(call);
        }

        [HttpDelete]
        [Route("{callId}")]
        public async Task<ActionResult> EndCall([FromRoute] string callId)
        {
            await this.callsService.EndCallAsync(callId);
            return this.Ok();
        }

        [HttpGet]
        [Route("active")]
        public async Task<ActionResult<List<CallDto>>> GetActiveCallsAsync()
        {
            var activeCallsList = await this.callsService.GetActiveCallsAsync();
            return this.Ok(activeCallsList);
        }

        [HttpGet]
        [Route("archived")]
        public async Task<ActionResult<PagedQueryResult<CallDto>>> GetArchivedCallsAsync([FromQuery] int pageNumber, int pageSize = 10)
        {
            var archivedCallsList = await this.callsService.GetArchivedCallsAsync(pageNumber, pageSize);
            return this.Ok(archivedCallsList);
        }
        */
    }
}
