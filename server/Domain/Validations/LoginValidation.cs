using FluentValidation;
using server.Domain.Models;

namespace server.Domain.Validations
{
    public class LoginValidation:AbstractValidator<Login>{
        public LoginValidation()
        { 
            RuleFor(x=>x.UserName).MinimumLength(8).WithMessage("UserName must be at least 8 characters long.");

             RuleFor(x => x.Password)
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
            .MaximumLength(25).WithMessage("Password must be no more than 25 characters long")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one number")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character")
            .Must(password => !password.Contains(" ")).WithMessage("Password must not contain any white space");   
        }
    }
}