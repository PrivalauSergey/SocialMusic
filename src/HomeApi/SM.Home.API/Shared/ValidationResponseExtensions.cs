using FluentValidation.Results;

namespace SM.Home.API.Shared
{
    public static class ValidationResponseExtensions
    {
        public static ValidationResponse ToResponse(this ValidationResult validationResult)
        {
            return new ValidationResponse
            {
                Error = "validation error",
                Data = validationResult.ToDictionary()
            };
        }
    }
}
