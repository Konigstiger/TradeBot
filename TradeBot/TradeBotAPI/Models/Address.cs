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
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }

    }
}
