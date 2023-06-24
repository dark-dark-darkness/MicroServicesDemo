using Carter;

using MicroServicesDemo.PlatformsService.ServiceInstaller;

var builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddEndpoints()
       .AddDatabase(builder.Configuration, builder.Environment)
       .AddI18n()
       .AddMapper()
       .AddValidator()
       .AddLog()
       .AddClients()
       .AddGrpcService()
       .AddGrpcClients()
       .AddRepository()
       .AddMassTransitForRabbitMQ(builder.Configuration);

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

app.MapGrpcServices();

app.Run();
