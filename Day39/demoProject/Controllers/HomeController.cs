using System.Diagnostics;
using demoProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace demoProject.Controllers
{
    public class HomeController : Controller
    {
        // Simple in-memory catalog
        private static readonly List<Product> _products =
        new()
        {
        new Product{ Id=1, Name="Product 1", Price=199.00m, ImageUrl="/img/p3.jpg"},
        new Product{ Id=2, Name="Product 2", Price=299.00m, ImageUrl="/img/p4.png"},
        new Product{ Id=3, Name="Product 3", Price=149.00m, ImageUrl="/img/p2.jpg"},
        new Product{ Id=4, Name="Product 4", Price=99.00m,  ImageUrl="/img/p1.jpg"},
        };

        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("anvitha");
            if (string.IsNullOrEmpty(user)) return RedirectToAction("Login", "Login");

            ViewBag.User = user;
            return View(_products);
        }

        // For CartController to read products
        public static Product? FindProduct(int id) => _products.FirstOrDefault(p => p.Id == id);
    }
}
