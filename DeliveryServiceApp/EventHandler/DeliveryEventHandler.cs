using DeliveryServiceApp.Data;
using DeliveryServiceApp.Models;
using MassTransit;
using OrderServiceApp.Events;
using OrderServiceApp.Models;
using Delivery = DeliveryServiceApp.Models.Delivery;

namespace DeliveryServiceApp.EventHandler;

public class DeliveryEventHandler : IConsumer<OrderCreateEvent>
{
    
    private readonly DSApplicationDbContext _context;

    public DeliveryEventHandler(DSApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<OrderCreateEvent> context)
    {

        var delivery = new Delivery()
        {
            OrderId = context.Message.OrderId,
            City = context.Message.City,
            Street = context.Message.Street
        };
        
        await _context.Deliveries.AddAsync(delivery);
        await _context.SaveChangesAsync();
        
    }
}