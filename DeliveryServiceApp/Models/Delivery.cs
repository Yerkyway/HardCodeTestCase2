using System.ComponentModel.DataAnnotations.Schema;
using OrderServiceApp.Models;

namespace DeliveryServiceApp.Models;

public class Delivery
{
    public int Id { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;

    public int OrderId { get; set; }
}