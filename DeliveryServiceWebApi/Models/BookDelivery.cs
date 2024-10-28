namespace DeliveryServiceWebApi.Models;
using OrderServiceApp.Models;

public class BookDelivery
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string  City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public Book Book { get; set; } = new Book();
    public decimal Price => Book.Price;
}