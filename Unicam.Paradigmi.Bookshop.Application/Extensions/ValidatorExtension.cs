using System.Text.RegularExpressions;
using FluentValidation;

namespace Unicam.Paradigmi.Bookshop.Application.Extensions;

public static class ValidatorExtension
{
    public static void RegEx<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilderOptions, string regex,
        string validationMessage)
    {
        if (regex == null) throw new ArgumentNullException(nameof(regex));
        ruleBuilderOptions.Custom((value, context) =>
        {
            var regEx = new Regex(regex);
            if (!regEx.IsMatch(value.ToString())) context.AddFailure(validationMessage);
        });
    }

    public static void ValidateCollection<T, TProperty>(
        this IRuleBuilderInitial<T, ICollection<TProperty>> ruleBuilderOptions,
        Predicate<TProperty> predicate,
        string validationMessage)
    {
        ruleBuilderOptions.Custom((value, context) =>
        {
            if (!value.All(predicate.Invoke)) context.AddFailure(validationMessage);
        });
    }

    public static void ValidateEmail<T>(this IRuleBuilderInitial<T, string> ruleBuilderInitial)
    {
        ruleBuilderInitial.NotNull().WithMessage("Email field can't be null")
            .MaximumLength(345).WithMessage("Email field can't exceed the maximum 345 characters")
            .RegEx("[a-zA-Z0-9._-]+@[a-zA-Z0-9]+.[a-z]{2,}", "Incorrect email format");
    }
}