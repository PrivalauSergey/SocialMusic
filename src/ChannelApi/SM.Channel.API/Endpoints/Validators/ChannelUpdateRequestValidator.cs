using FluentValidation;
using SM.Channel.API.Models.Requests;

namespace SM.Channel.API.Endpoints.Validators
{
    public class ChannelUpdateRequestValidator : AbstractValidator<ChannelUpdateRequest>
    {
        public ChannelUpdateRequestValidator()
        {
            RuleFor(x => x.ChannelId)
                .GreaterThan(0).WithMessage("Channel ID must be a positive number.");

            RuleFor(x => x.ChannelName)
                .NotEmpty().WithMessage("Channel name is required.");
        }
    }
}
