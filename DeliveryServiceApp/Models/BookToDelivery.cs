using System.ComponentModel.DataAnnotations.Schema;
using OrderServiceApp.Models;

namespace DeliveryServiceApp.Models;

public class BookToDelivery
{
    public int Id { get; set; }
    public string City { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public Book Book { get; set; } = new Book();
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price => Book.Price;

}