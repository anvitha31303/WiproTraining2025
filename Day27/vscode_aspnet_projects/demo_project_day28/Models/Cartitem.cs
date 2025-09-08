namespace demo_project_day28.Models;

public class Cartitem
{
    public int ProductId { get; set; }       // Links to Product
    public string ProductName { get; set; } = "";
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}