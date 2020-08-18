using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TradeBotAPI.Config;
using TradeBotAPI.Models;
using TradeBotAPI.Models.Validators;
using TradeBotAPI.Services;

namespace TradeBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
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

        public PersonController(IBrokerService service)
        {
            this.service = service;
        }

        // GET: api/person
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public bool Thing()
        {
            var result = false;

            var person = new Person();
            person.FirstName = "Mariano";
            person.LastName = "Rodriguez";
            person.CustomerName = "Mariano Rodriguez";
            person.PersonType = "person";
            person.EmailAddress = "mariano.rodriguez@southworks.com";
            person.Address = new Address();
            person.Address.Postcode = "5008";

            var list = new List<Pet>();
            list.Add(new Pet("Ace"));
            list.Add(new Pet("Apollo"));
            list.Add(new Pet("Benny"));
            list.Add(new Pet("Bruno"));
            list.Add(new Pet("Brutus"));
            list.Add(new Pet("Buddy"));
            list.Add(new Pet("Cody"));
            list.Add(new Pet("Duke"));
            list.Add(new Pet("Rocco"));
            list.Add(new Pet("Rocky"));
            list.Add(new Pet("Winston")); // 11 pets: should fail validations.

            person.Pets = list;

            var validator = new PersonValidator();

            ValidationResult results = validator.Validate(person);
            
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            return results.IsValid;
        }


    }
}
