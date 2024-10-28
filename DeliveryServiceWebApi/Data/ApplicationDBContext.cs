using DeliveryServiceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceWebApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {
        
    }
    
    public DbSet<BookDelivery> BookDeliveries { get; set; }
}