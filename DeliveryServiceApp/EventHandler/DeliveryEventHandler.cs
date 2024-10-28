using MassTransit;
using OrderServiceApp.Events;

namespace DeliveryServiceApp.EventHandler;

public class DeliveryEventHandler : IConsumer<OrderServiceEvent>
{
    public Task Consume(ConsumeContext<OrderServiceEvent> context)
    {
        
        Console.WriteLine(context.Message.Message);
        return Task.CompletedTask;
    }
}