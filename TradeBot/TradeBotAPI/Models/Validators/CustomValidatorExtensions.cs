using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBotAPI.Models.Validators
{
    public static class CustomValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidPersonType<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new PersonTypeValidator());
        }
    }
}
