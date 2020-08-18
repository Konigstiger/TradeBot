using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using TradeBotAPI.Models.IOL;

namespace TradeBotAPI.Models
{
    /// <summary>
    /// Just a person.
    /// </summary>
    public class Person
    {
        public string PersonType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }

        // new List to illustrate custom validators
        public IList<Pet> Pets { get; set; } = new List<Pet>();

    }
}
