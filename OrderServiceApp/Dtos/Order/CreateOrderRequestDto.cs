namespace OrderServiceApp.Dtos;

public class CreateOrderRequestDto
{
    public int BookId { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; } = DateTime.Now;
}