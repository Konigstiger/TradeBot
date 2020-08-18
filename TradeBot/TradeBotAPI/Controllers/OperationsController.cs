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
    public class OperationsController : ControllerBase
    {
        /*
        GET: read existing data
        POST: create new data
        PUT: update existing data
        PATCH: update a subset of existing data
        DELETE: remove existing data         
        */

        // TODO: just copypasted. Design the exposed actions.
        // maybe I will need to separate this controller in one to buy, and other to sell.
        // de todas formas, es mejor que esté todo en uno solo.

        // ENDPOINTS:
        // POST /api/v2/operar/Comprar
        /*
         ComprarBindingModel {
            mercado (string): = ['bCBA', 'nYSE', 'nASDAQ', 'aMEX', 'bCS', 'rOFX'],
            simbolo (string): ,
            cantidad (number): ,
            precio (number): ,
            plazo (string): = ['t0', 't1', 't2'],
            validez (string):
            }
         */


        // POST /api/v2/operar/Vender


        // GET: api/Portfolio
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public static async Task<Operation> GetOperationAsync(IOperationService service)
        {
            var result = await service.GetOperationAsync();
            return result;
        }

        
        // POST: api/Operation
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Operation/5
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
