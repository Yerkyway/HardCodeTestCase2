using OrderServiceApp.Models;

namespace DeliveryServiceApp.Dto;

public class DeliveryDto
{
    public int Id { get; set; }
    public string City { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int OrderId { get; set; }

}