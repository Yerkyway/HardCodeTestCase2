using DeliveryServiceApp.Data;
using DeliveryServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceApp.Controllers;

[Route("api/deliveryStatus")]
[ApiController]
public class DeliveryStatusController : Controller
{
    
    private readonly DSApplicationDbContext _context;
    private readonly ILogger<DeliveryStatusController> _logger;

    public DeliveryStatusController(DSApplicationDbContext context, ILogger<DeliveryStatusController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("{orderId}/status")]
    public async Task<IActionResult> GetDeliveryStatusByOrderId(int orderId)
    {
        var delivery = await _context.Deliveries.FirstOrDefaultAsync(d=>d.OrderId == orderId);
        
        if (delivery == null)
        {
            return NotFound();
        }

        delivery.DeliveryStatus = DeliveryStatus.DELIVERED;
        _logger.LogInformation("Delivery status for Order Id {orderId} was changed to DELIVERED", orderId);
        
        return Ok(new { OrderId = orderId, Status = delivery.DeliveryStatus });
        
    }
}