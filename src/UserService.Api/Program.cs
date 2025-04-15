using BaseChord.Api;
using BaseChord.Api.Logging;
using Microsoft.AspNetCore.Builder;
using UserService.Application;
using UserService.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.AddCustomizedLogging();

builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.ConfigureBaseApp();

app.Run();
