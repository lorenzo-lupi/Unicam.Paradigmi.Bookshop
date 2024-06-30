using System.Text.RegularExpressions;
using FluentValidation;

namespace Unicam.Paradigmi.Bookshop.Application.Extensions;

public static class ValidatorExtension
{
    public static void RegEx<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, string regex, string validationMessage)
    {
        ruleBuilder.Custom((value, context) =>
        {
            var regEx = new Regex(regex);
            if (!regEx.IsMatch(value.ToString()))
            {
                context.AddFailure(validationMessage);
            }
        });
    }
}