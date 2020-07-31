﻿using System;
using System.Collections.Generic;

namespace TradeBot.Core
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public List<DomainEventBase> Events = new List<DomainEventBase>();
    }
}
