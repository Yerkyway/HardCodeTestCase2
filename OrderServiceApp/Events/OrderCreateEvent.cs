using OrderServiceApp.Models;

namespace OrderServiceApp.Events;

public class OrderCreateEvent
{
    public int OrderId { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
}