namespace demoProject.Models
{
    public class Cart
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal LineTotal => UnitPrice * Quantity;
    }
}
