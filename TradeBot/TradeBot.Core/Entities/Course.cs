using System;
using System.Collections.Generic;
using System.Linq;

namespace TradeBot.Core
{
    public class Course : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
