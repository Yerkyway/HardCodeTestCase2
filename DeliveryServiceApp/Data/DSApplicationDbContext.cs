using DeliveryServiceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceApp.Data;

public class DSApplicationDbContext : DbContext
{
    public DSApplicationDbContext(DbContextOptions<DSApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Delivery> Deliveries { get; set; }
    
}