
using demo_project_day28.Models;

namespace demo_project_day28.Services;
public static class Sampledata
{
    public static List<Product> Products = new()
    {
        new Product { ProductId = 1, Name = "Product 1", Price = 10 },
        new Product { ProductId = 2, Name = "Product 2", Price = 20 },
        new Product { ProductId = 3, Name = "Product 3", Price = 15 },
        new Product { ProductId = 4, Name = "Product 4", Price = 25 },
    };
}
