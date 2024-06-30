using FluentValidation;
using Unicam.Paradigmi.Bookshop.Application.Models.Requests;

namespace Unicam.Paradigmi.Bookshop.Application.Validators;

public class RemoveCategoryRequestValidator : AbstractValidator<RemoveCategoryRequest>
{
    public RemoveCategoryRequestValidator()
    {
        RuleFor(r => r.Id)
            .GreaterThanOrEqualTo(0).WithMessage("Id can't have negative values");
    }
}