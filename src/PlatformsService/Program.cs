using Carter;

using MicroServicesDemo.PlatformsService.ServiceInstaller;

var builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddEndpoints()
       .AddDatabase()
       .AddI18n()
       .AddMapper()
       .AddValidator()
       .AddLog()
       .AddClients()
       .AddRepository();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseI18n();

app.UseHttpLogging();

app.UseAuthorization();

app.MapCarter();

app.Run();
