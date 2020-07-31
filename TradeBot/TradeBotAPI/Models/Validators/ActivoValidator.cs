using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TradeBotAPI.Models.IOL;

namespace TradeBotAPI.Models
{
    public class ActivoValidator: AbstractValidator<Activo>
    {
        public ActivoValidator()
        {
            RuleFor(x => x.cantidad).NotNull();

            RuleFor(x => x.ppc).GreaterThan(0).WithMessage("The PPC must be at greather than 0.");
            /*
            RuleFor(x => x.titulo)
                .NotEmpty()
                .WithMessage("The Product Name cannot be blank.")
                .Length(0, 100)
                .WithMessage("The Product Name cannot be more than 100 characters.");

            RuleFor(x => x.valorizado)
                .NotEmpty()
                .WithMessage("The Product Description must be at least 150 characters long.");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("The Product Price must be at greather than 0.");
            */
        }
    }
}
