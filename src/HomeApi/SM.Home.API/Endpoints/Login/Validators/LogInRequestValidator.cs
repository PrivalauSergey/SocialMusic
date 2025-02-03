using FluentValidation;
using FluentValidation.Validators;
using SM.Home.API.Endpoints.Account.Models;
using SM.Home.API.Helpers;

namespace SM.Home.API.Endpoints.Account.Validators
{
    public class LogInRequestValidator : AbstractValidator<LoginRequest>
    {
        public LogInRequestValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
