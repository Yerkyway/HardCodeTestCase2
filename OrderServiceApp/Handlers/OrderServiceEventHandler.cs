using MassTransit;
using OrderServiceApp.Events;

namespace OrderServiceApp.Handlers;

public class OrderServiceEventHandler : IConsumer<OrderServiceEvent>
{
    public Task Consume(ConsumeContext<OrderServiceEvent> context)
    {
        Console.WriteLine(context.Message.Message);
        return Task.CompletedTask;
    }
}