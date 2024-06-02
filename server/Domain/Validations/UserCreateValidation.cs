using FluentValidation;
using server.Domain.DTOs;

namespace server.Domain.Validations
{
    public class UserCreateValidation:AbstractValidator<UserCreateDto>{
        public UserCreateValidation()
        { 
            RuleFor(x=>x.UserName).Length(8);
            RuleFor(x=>x.Email).EmailAddress(); 
            RuleFor(x => x.Phone)
            .Length(10).WithMessage("Phone number must be exactly 10 digits.")
            .Matches(@"^\d{10}$").WithMessage("Phone number must contain only digits.");
            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");
        }
    }
}