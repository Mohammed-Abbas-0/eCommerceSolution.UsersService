using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(idx => idx.Email)
            .NotEmpty().WithMessage("Email is reqiured")
            .EmailAddress().WithMessage("Invalid email address format");

        RuleFor(idx => idx.Password)
            .NotEmpty().WithMessage("Password is required");

        RuleFor(idx => idx.PersonName)
            .NotEmpty().WithMessage("PersonName is required")
            .Length(1,50).WithMessage("Person Name should be 1 to 50 characters long");

        RuleFor(idx => idx.Gender)
            .IsInEnum().WithMessage("Invalid gender option");
    }
}
