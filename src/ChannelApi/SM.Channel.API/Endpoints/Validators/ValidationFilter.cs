using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SM.Channel.API.Endpoints.Validators
{
    public class ValidationFilter<T> : IEndpointFilter where T : class
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();
            if (validator != null)
            {
                var argument = context.Arguments.FirstOrDefault(arg => arg is T) as T;
                if (argument != null)
                {
                    var validationResult = await validator.ValidateAsync(argument);
                    if (!validationResult.IsValid)
                    {
                        return Results.BadRequest(validationResult.Errors);
                    }
                }
            }
            return await next(context);
        }
    }
}
