using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SM.Home.API.Configurations;
using SM.Home.API.Extensions;

namespace SM.Home.API
{
    public static class Programm
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.MapGet("/", () => "Hello world");

            app.Run();
        }
    }
}
