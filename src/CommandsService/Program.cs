using Carter;

using MicroServicesDemo.CommandsService.ServiceInstaller;

var builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddApi()
        //.AddDatabase(builder.Configuration, builder.Environment)
       .AddI18n()
       .AddMapper()
       .AddValidator()
       .AddLog()
       .AddRepository();

var app = builder.Build();

app.UseI18n();

app.UseHttpLogging();

app.UseAuthorization();

app.MapCarter();

app.Run();
