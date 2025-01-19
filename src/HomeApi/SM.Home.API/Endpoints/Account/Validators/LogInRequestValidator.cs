using FluentValidation;
using FluentValidation.Validators;
using SM.Home.API.Endpoints.Account.Models;
using SM.Home.API.Helpers;
using System.Text.RegularExpressions;

namespace SM.Home.API.Endpoints.Account.Validators
{
    public class AccountCreateRequestValidator : AbstractValidator<AccountCreateRequest>
    {
        public AccountCreateRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(15);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .Matches(RegexHelper.AtLeastOneCapitalSymbol)
                .Matches(RegexHelper.AtLeastOneNonSymbol);

            RuleFor(x => x.Email)
                 .NotEmpty()
                 .Matches(RegexHelper.EmailValidationRegex);
        }
    }
}
