using System.ComponentModel.DataAnnotations.Schema;

namespace OrderServiceApp.Models;

public class Orders
{
    public int Id { get; set; }
    public int QuantityOfBooks { get; set; }
    
    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }
    public Book Book { get; set; }
}