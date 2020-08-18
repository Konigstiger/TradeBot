using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBotAPI.Models.Validators
{
    public class PersonTypeValidator : PropertyValidator
    {
        public PersonTypeValidator() : base("Person type {PropertyValue} is not a valid type")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string PersonType = (string)context.PropertyValue;
            if (PersonType.ToLower() == "person" || PersonType.ToLower() == "company")
                return true;

            return false;
        }
    }
}
