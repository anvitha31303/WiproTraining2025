using demoProject.Helpers;
using demoProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace demoProject.Controllers
{
    public class OrderController : Controller
    {
        private const string CartKey = "CART";
        private const string BillKey = "BILL";

        private List<Cart> GetCart()
            => HttpContext.Session.GetObject<List<Cart>>(CartKey) ?? new List<Cart>();

        [HttpGet]
        public IActionResult Checkout()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
                return RedirectToAction("Login", "Login");

            var cart = GetCart();
            if (!cart.Any()) return RedirectToAction("Index", "Cart");
            ViewBag.CartTotal = cart.Sum(c => c.LineTotal);
            return View(new Orders());
        }

        [HttpPost]
        public IActionResult Checkout(Orders info)
        {
            var cart = GetCart();
            if (!cart.Any())
                return RedirectToAction("Index", "Cart");

            // create a simple bill object and store to session for display
            var bill = new
            {
                Customer = info,
                Items = cart,
                Subtotal = cart.Sum(c => c.LineTotal),
                Tax = Math.Round(cart.Sum(c => c.LineTotal) * 0.1m, 2), // 10% demo tax
            };
            var total = bill.Subtotal + bill.Tax;

            HttpContext.Session.SetObject(BillKey, new { bill.Customer, bill.Items, bill.Subtotal, bill.Tax, Total = total });

            // clear cart after confirming
            HttpContext.Session.Remove(CartKey);

            return RedirectToAction("Bill");
        }

        public IActionResult Bill()
        {
            var bill = HttpContext.Session.GetObject<dynamic>(BillKey);
            if (bill is null) return RedirectToAction("Index", "Home");
            return View(bill);
        }
    }
}
