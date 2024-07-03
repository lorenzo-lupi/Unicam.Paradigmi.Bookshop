using FluentValidation;
using Unicam.Paradigmi.Bookshop.Application.Extensions;
using Unicam.Paradigmi.Bookshop.Application.Models.Requests;

namespace Unicam.Paradigmi.Bookshop.Application.Validators;

public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(r => r.Title)
            .NotEmpty().WithMessage("Title can't be empty");
        RuleFor(r => r.Author)
            .NotEmpty().WithMessage("Author field can't be empty");
        RuleFor(r => r.CategoryIds)
            .ValidateCollection(v => v >= 0, "Invalid category Id format");
    }
}