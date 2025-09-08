namespace demo_project_day28.Models;
public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; } = "";
    public List<CartItem> Items { get; set; } = new();
    public decimal Total => Items.Sum(i => i.Price * i.Quantity);
}