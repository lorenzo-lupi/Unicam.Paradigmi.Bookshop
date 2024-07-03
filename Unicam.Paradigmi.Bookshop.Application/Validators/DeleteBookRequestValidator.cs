using FluentValidation;
using Unicam.Paradigmi.Bookshop.Application.Models.Requests;

namespace Unicam.Paradigmi.Bookshop.Application.Validators;

public class DeleteBookRequestValidator : AbstractValidator<DeleteBookRequest>
{
    public DeleteBookRequestValidator()
    {
        RuleFor(r => r.Id)
            .GreaterThanOrEqualTo(0).WithMessage("Wrong id format");
    }
}