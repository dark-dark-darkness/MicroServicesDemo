using FluentValidation;

namespace MicroServicesDemo.CommandsService.ServiceInstaller;

public static class ValidatorServiceInstaller
{
    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        return services;
    }
}
