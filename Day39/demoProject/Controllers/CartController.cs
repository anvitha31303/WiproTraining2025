using demoProject.Helpers;
using demoProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace demoProject.Controllers
{
    public class CartController : Controller
    {
        private const string CartKey = "CART";

        private List<Cart> GetCart()
            => HttpContext.Session.GetObject<List<Cart>>(CartKey) ?? new List<Cart>();

        private void SaveCart(List<Cart> cart)
            => HttpContext.Session.SetObject(CartKey, cart);

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
                return RedirectToAction("Login", "Login");

            var cart = GetCart();
            ViewBag.Total = cart.Sum(c => c.LineTotal);
            return View(cart);
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            var product = HomeController.FindProduct(id);
            if (product is null) return RedirectToAction("Index", "Home");

            var cart = GetCart();
            var line = cart.FirstOrDefault(c => c.ProductId == id);
            if (line == null)
                cart.Add(new Cart { ProductId = id, ProductName = product.Name, UnitPrice = product.Price, Quantity = 1 });
            else
                line.Quantity += 1;

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(int id, int qty)
        {
            var cart = GetCart();
            var line = cart.FirstOrDefault(c => c.ProductId == id);
            if (line != null)
            {
                if (qty <= 0) cart.Remove(line);
                else line.Quantity = qty;
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var cart = GetCart();
            cart.RemoveAll(c => c.ProductId == id);
            SaveCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            SaveCart(new List<Cart>());
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Increase(int id)
        {
            var cart = GetCart();
            var line = cart.FirstOrDefault(c => c.ProductId == id);
            if (line != null)
            {
                line.Quantity++;
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Decrease(int id)
        {
            var cart = GetCart();
            var line = cart.FirstOrDefault(c => c.ProductId == id);
            if (line != null)
            {
                line.Quantity--;
                if (line.Quantity <= 0) // remove if quantity goes to 0
                    cart.Remove(line);

                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

    }
}