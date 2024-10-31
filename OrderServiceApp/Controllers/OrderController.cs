using AutoMapper;
using AutoMapper.QueryableExtensions;
using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderServiceApp.Data;
using OrderServiceApp.Dtos;
using OrderServiceApp.Events;
using OrderServiceApp.Models;

namespace OrderServiceApp.Controllers;

[Route("/api/order")]
[ApiController]
public class OrderController : Controller
{
    private readonly ApplicationDBContext _context;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<OrderController> _logger;


    public OrderController(ApplicationDBContext context, IMapper mapper, IPublishEndpoint publishEndpoint, ILogger<OrderController> logger)
    {
        _context = context;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _context.Orders
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        
        
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById([FromRoute] int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        
        

        return Ok(_mapper.Map<OrderDto>(order));
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequestDto orderRequestDto)
    {
        _logger.LogInformation("Creating order");
        
        var order = _mapper.Map<Orders>(orderRequestDto);
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        
        _logger.LogInformation("Created order");
        
        _logger.LogInformation("Publishing OrderCreateEvent for Order ID: {OrderId} to RabbitMQ", order.Id);
        
        await _publishEndpoint.Publish(new OrderCreateEvent()
            { OrderId = order.Id, City = order.City, Street = order.Street });
        
        _logger.LogInformation("OrderCreateEvent for Order ID {OrderId} was successfully published to RabbitMQ", order.Id);
        
        return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, _mapper.Map<OrderDto>(order));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderRequestDto orderRequestDto)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x=>x.Id == id);
        if (order==null)
        {
            return NotFound();
        }
        
        _mapper.Map(orderRequestDto, order);
        await _context.SaveChangesAsync();
        
        return Ok(_mapper.Map<OrderDto>(order));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var orders = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        if (orders == null) 
        {
            return NotFound();
        }
        _context.Orders.Remove(orders);
        await _context.SaveChangesAsync();
        
        
        
        return NoContent();
    }
}