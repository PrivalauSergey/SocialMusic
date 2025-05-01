using FluentValidation;
using SM.Home.API.Endpoints.Account.Models;
using SM.Home.API.Helpers;

namespace SM.Home.API.Endpoints.Account.Validators
{
    public class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(15);

            RuleFor(x => x.EncryptedPassword)
                .NotEmpty();

            RuleFor(x => x.Email)
                 .NotEmpty()
                 .Matches(RegexHelper.EmailValidationRegex);
        }
    }
}
