using System.Reflection;

using MassTransit;

namespace MicroServicesDemo.CommandsService.ServiceInstaller;

public static class MassTransitServiceInstaller
{
    // ReSharper disable once InconsistentNaming
    public static IServiceCollection AddMassTransitForRabbitMQ(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();

            x.SetInMemorySagaRepositoryProvider();

            var entryAssembly = Assembly.GetEntryAssembly();

            x.AddConsumers(entryAssembly);
            x.AddSagaStateMachines(entryAssembly);
            x.AddSagas(entryAssembly);
            x.AddActivities(entryAssembly);

            x.UsingRabbitMq(
                (ctx, cfg) =>
                {
                    cfg.ConfigureEndpoints(ctx);
                    cfg.Host(
                        configuration["RabbitMQ:Host"],
                        ushort.Parse(configuration["RabbitMQ:Port"]!),
                        "/",
                        h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        }
                    );
                }
            );
        });

        return services;
    }
}
