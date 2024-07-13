using FluentValidation;
using Unicam.Paradigmi.Bookshop.Application.Extensions;
using Unicam.Paradigmi.Bookshop.Application.Models.Requests;

namespace Unicam.Paradigmi.Bookshop.Application.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(u => u.Password)
            .NotNull().WithMessage("Password's field can't be null")
            .NotEmpty().WithMessage("Password's field can't be empty");
        RuleFor(u => u.Email)
            .ValidateEmail();
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Name field can't be empty");
        RuleFor(u => u.Surname)
            .NotEmpty().WithMessage("Surname field can't be empty");
    }
}