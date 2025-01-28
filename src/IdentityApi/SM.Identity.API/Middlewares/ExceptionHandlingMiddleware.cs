using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace SM.Identity.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                LogToConsole(ex, httpContext);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var responseEntity = new
            {
                Code = statusCode,
                ExceptionMessage = exception.Message,
                State = "Exception"
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(responseEntity));
        }

        private void LogToConsole(Exception ex, HttpContext context)
        {
            var enhancedStackTrace = ex.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();

            // Get a name of a class in which an exception occurred
            string source = enhancedStackTrace.Split()[4].Split('.')[^2];

            _logger.LogError("\tExceptionType: {ExceptionType}\n\tMessage: {Message}\n\tSource: {Source}\n\tStackTrace: {StackTrace}",
                ex.GetType(),
                ex.Message,
                source,
                enhancedStackTrace);
        }
    }
}
