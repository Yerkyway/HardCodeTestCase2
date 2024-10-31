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
    private readonly ILogger<DeliveryEventHandler> _logger;

    public DeliveryEventHandler(DSApplicationDbContext context, ILogger<DeliveryEventHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<OrderCreateEvent> context)
    {
        try
        {
            _logger.LogInformation("Received OrderCreateEvent for Order ID: {OrderId}", context.Message.OrderId);

            var delivery = new Delivery()
            {
                OrderId = context.Message.OrderId,
                City = context.Message.City,
                Street = context.Message.Street
            };

            await _context.Deliveries.AddAsync(delivery);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Delivered created for Order ID {OrderId} and saved in the database",
                context.Message.OrderId);
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, "An error occured while processing OrderCreateEvent for Order ID: {OrderId", context.Message.OrderId);
            throw;
        }
        
    }
}