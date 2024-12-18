﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace OrderServiceApp.Models;

public class Orders
{
    public int Id { get; set; }
    
    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }
    public Book Book { get; set; }
    
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; } = DateTime.Now;
}