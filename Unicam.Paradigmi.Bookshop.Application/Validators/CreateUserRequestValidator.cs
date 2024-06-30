using FluentValidation;
using Google.Protobuf.WellKnownTypes;
using Unicam.Paradigmi.Bookshop.Application.Extensions;
using Unicam.Paradigmi.Bookshop.Application.Models.Requests;
using Unicam.Paradigmi.Bookshop.Models.Repositories;

namespace Unicam.Paradigmi.Bookshop.Application.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {

        RuleFor(u => u.Password)
            .NotNull().WithMessage("Password's field can't be null")
            .NotEmpty().WithMessage("Password's field can't be empty");
        RuleFor(u => u.Email)
            .NotNull().WithMessage("Email field can't be null")
            .MaximumLength(345).WithMessage("Email field can't exceed the maximum 345 characters")
            .RegEx("[a-zA-Z0-9._-]+@[a-zA-Z0-9]+.[a-z]{2,}", "Incorrect email format");
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Name field can't be empty");
        RuleFor(u => u.Surname)
            .NotEmpty().WithMessage("Surname field can't be empty");
    }
    
}