using Microsoft.AspNetCore.Builder;
using SM.Identity.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
await builder.RegisterServices();