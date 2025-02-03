using Microsoft.AspNetCore.Builder;
using SM.Identity.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();
app.RegisterMiddlewares();

app.Run();