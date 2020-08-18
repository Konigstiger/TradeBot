using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace TradeBotAPI.Models.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            // chained standard rules
            RuleFor(m => m.CustomerName).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(m => m.EmailAddress).EmailAddress();

            // sample conditional rules
            RuleFor(m => m.FirstName).NotEmpty().WithMessage("First name must be specified.")
                .When(m => m.PersonType.ToLower() == "person");
            RuleFor(m => m.LastName).NotEmpty().WithMessage("Last name must be specified.")
                .When(m => m.PersonType.ToLower() == "person");

            // custom rule: we validate that personType is "person" or "company"
            RuleFor(m => m.PersonType).NotEmpty().ValidPersonType();

            // new: reusing a existing validator for a child property
            RuleFor(m => m.Address).SetValidator(new AddressValidator());

            // first basic implementation
            //RuleFor(x => x.Pets).Must(list => list.Count < 10)
            //  .WithMessage("The list must contain fewer than 10 items");

            // after adding CustomValidators (with this extension method)
            RuleFor(x => x.Pets).ListMustContainFewerThan(10);
        }

    }
}

