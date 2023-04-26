public class Customer
{
    public string? Name { get; set; }
    public ICollection<Order>? Orders { get; set; }
}
public class Order
{
    public string? Product { get; set; }
    public decimal Price { get; set; }
}