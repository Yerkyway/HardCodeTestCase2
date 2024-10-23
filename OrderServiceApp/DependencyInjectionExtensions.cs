using System.Reflection;
using MassTransit;

namespace OrderServiceApp;

public static class DependencyInjectionExtensions
{
    private static IEnumerable<Type> FindConsumers(params Assembly[] assemblies)
    {
        var consumerInterfaceType = typeof(IConsumer<>);
        
        return assemblies.SelectMany(assembly => assembly.GetTypes()
            .Where(t=> t.GetInterfaces()
                .Any(i=> i.IsGenericType && i.GetGenericTypeDefinition()==consumerInterfaceType)));
    }

    public static void RegisterConsumersFrom(this IBusRegistrationConfigurator cfg, params Assembly[] consumerAssemblies)
    {
        var consumers = FindConsumers(consumerAssemblies);

        foreach (var consumer in consumers)
        {
            cfg.AddConsumer(consumer);
        }
    }

    public static void SetHost(this IRabbitMqBusFactoryConfigurator cfg, IConfiguration configuration)
    {
        cfg.Host($"{configuration["RabbitMQ:HostName"]}",
            Convert.ToUInt16(configuration["RabbitMQ:Port"]),
            configuration["RabbitMQ:VirtualHost"], h =>
            {
                h.Username(configuration["RabbitMQ:UserName"]);
                h.Password(configuration["RabbitMQ:Password"]);
            });
    }
}