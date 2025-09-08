using Microsoft.AspNetCore.Mvc;

namespace demoProject.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
        
            if (!string.IsNullOrWhiteSpace(anvitha) && password == "34")
            {
                HttpContext.Session.SetString("UserName", anvitha);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid credentials.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
