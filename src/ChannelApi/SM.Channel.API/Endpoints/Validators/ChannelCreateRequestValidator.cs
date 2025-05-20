using FluentValidation;
using SM.Channel.API.Models.Requests;

namespace SM.Channel.API.Endpoints.Validators
{
    public class ChannelCreateRequestValidator : AbstractValidator<ChannelCreateRequest>
    {
        public ChannelCreateRequestValidator()
        {
            RuleFor(x => x.ChannelName)
                .NotEmpty().WithMessage("Channel name is required.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("User ID must be a positive number.");
        }
    }
}
