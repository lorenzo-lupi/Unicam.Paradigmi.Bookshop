using FluentValidation;
using Unicam.Paradigmi.Bookshop.Application.Extensions;
using Unicam.Paradigmi.Bookshop.Application.Models.Requests;

namespace Unicam.Paradigmi.Bookshop.Application.Validators;

public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
{
    public UpdateBookRequestValidator()
    {
        RuleFor(r => r.Id)
            .GreaterThanOrEqualTo(0).WithMessage("Illegal Id format");
        RuleFor(r => r.CategoryIds)
            .ValidateCollection(v => v >= 0, "Invalid category Id format");
    }
}