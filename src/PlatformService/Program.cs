using Carter;

using MicroServicesDemo.PlatformService.Data.Repositories;
using MicroServicesDemo.PlatformService.ServiceInstaller;

var builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddApi()
       .AddDatabase()
       .AddI18n()
       .AddMapper()
       .AddValidator()
       .AddLog();

builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));

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
