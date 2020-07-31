using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace TradeBotAPI.Models
{
    public class HoldingValidator: AbstractValidator<Holding>
    {
        public HoldingValidator()
        {
            RuleFor(holding => holding.Quantity).NotNull();
        }
    }
}
