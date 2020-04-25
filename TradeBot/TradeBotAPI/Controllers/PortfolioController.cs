using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TradeBotAPI.Models;
using TradeBotAPI.Services;

namespace TradeBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        // GET: api/Portfolio
        [HttpGet]
        public IEnumerable<Portfolio> Get()
        {
            return null;
        }

        // GET: api/Portfolio/5
        [HttpGet("{id}", Name = "Get")]
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
