using FluentValidation;
using Unicam.Paradigmi.Bookshop.Application.Extensions;
using Unicam.Paradigmi.Bookshop.Application.Models.Requests;

namespace Unicam.Paradigmi.Bookshop.Application.Validators;

public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
{
    public CreateTokenRequestValidator()
    {
        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("password field can't be left empty");
        RuleFor(u => u.Email)
            .ValidateEmail();
    }
}