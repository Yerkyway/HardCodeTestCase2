﻿using DeliveryServiceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceApp.Data;

public class DSApplicationDbContext : DbContext
{
    public DSApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Delivery> Deliveries { get; set; }
}