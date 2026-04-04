using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace SM.Home.API.Filters
{
    public class SecurityHeadersEndpointFilter : IEndpointFilter
    {
        private static readonly StringValues ContentSecurityPolicy = new StringValues("default-src 'self'; script-src 'self' 'unsafe-inline' 'unsafe-eval'; font-src fonts.gstatic.com; style-src 'self' fonts.googleapis.com 'unsafe-inline'; img-src 'self' data:");
        private static readonly StringValues Referer = new StringValues("no-referrer");
        private static readonly StringValues StrictTransportSecurity = new StringValues("max-age=31536000; includeSubDomains; preload");
        private static readonly StringValues XContentTypeOptions = new StringValues("nosniff");
        private static readonly StringValues XFrameOptions = new StringValues("DENY");
        private static readonly StringValues XXSSProtection = new StringValues("1; mode=block");

        public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var response = context.HttpContext.Response;
            response.Headers.ContentSecurityPolicy = ContentSecurityPolicy;
            response.Headers.Referer = Referer;
            response.Headers.StrictTransportSecurity = StrictTransportSecurity;
            response.Headers.XContentTypeOptions = XContentTypeOptions;
            response.Headers.XFrameOptions = XFrameOptions;
            response.Headers.XXSSProtection = XXSSProtection;

            return await next(context);
        }
    }
}