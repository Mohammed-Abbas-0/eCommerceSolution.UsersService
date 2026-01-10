using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator:AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(idx => idx.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address format");

        RuleFor(idx => idx.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
