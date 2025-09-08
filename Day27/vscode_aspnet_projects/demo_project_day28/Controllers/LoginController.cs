using Microsoft.AspNetCore.Mvc;
using demo_project_day28.Models;
using demo_project_day28.Helpers;

namespace demo_project_day28.Controllers;
public class LoginController : Controller
{
    const string SESSION_USER = "USERNAME";
    // GET: /Account/Login
    public IActionResult Login()
    {
        return View();
    }
    // POST: /Account/Login
    [HttpPost]
    public IActionResult Login(Login model)
    {
        if (model.Username == "admin" && model.Password == "123")
        {
            HttpContext.Session.SetString(SESSION_USER, model.Username);
            return RedirectToAction("Index", "Home");
        }
        ViewBag.Error = "Invalid username or password";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
