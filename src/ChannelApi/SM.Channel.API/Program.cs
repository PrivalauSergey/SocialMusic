using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SM.Channel.API.Data;
using SM.Channel.API.Endpoints;
using SM.Channel.API.Repositories;
using SM.Channel.API.Services;
using AutoMapper;
using SM.Channel.API.Mappers;
using SM.Channel.API.Repositories.Interfaces;
using FluentValidation.AspNetCore;
using FluentValidation;
using SM.Channel.API.Endpoints.Validators;
using SM.Channel.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("ChannelDB"));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutomapperProfile());
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddValidatorsFromAssemblyContaining<ChannelCreateRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddTransient<IChannelRepository, ChannelRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IChannelUserRepository, ChannelUserRepository>();
builder.Services.AddTransient<IChannelService, ChannelService>();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapChannelEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();