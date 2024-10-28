using AutoMapper;
using AutoMapper.QueryableExtensions;
using DeliveryServiceApp.Data;
using DeliveryServiceApp.Dto;
using DeliveryServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderServiceApp.Data;
using OrderServiceApp.Dtos;

namespace DeliveryServiceApp.Controllers;

[Route("api/delivery")]
[ApiController]
public class DeliveryController : ControllerBase
{
    
    private readonly DSApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public DeliveryController(DSApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var deliveries = await _context.Deliveries
            .ProjectTo<DeliveryDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        
        return Ok(deliveries);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var delivery = await _context.Deliveries.FindAsync(id);
        if (delivery == null)
        {
            return NotFound();
        }
        
        return Ok(_mapper.Map<DeliveryDto>(delivery));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDeliveryRequestDto deliveryDto)
    {
        var delivery = _mapper.Map<Delivery>(deliveryDto);
        await _context.Deliveries.AddAsync(delivery);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetById), new { id = delivery.Id }, _mapper.Map<DeliveryDto>(delivery));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDeliveryRequestDto deliveryDto)
    {
        var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == id);
        if (delivery==null) 
        {
            return NotFound();
        }
        
        _mapper.Map(deliveryDto, delivery);
        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<DeliveryDto>(delivery));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var delivery = await _context.Deliveries.FirstOrDefaultAsync(x=>x.Id==id);
        if (delivery == null)
        {
            return NotFound();
        }

        _context.Deliveries.Remove(delivery);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
}