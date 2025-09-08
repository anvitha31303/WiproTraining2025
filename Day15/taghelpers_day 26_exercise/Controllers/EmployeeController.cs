using Microsoft.AspNetCore.Mvc;
using taghelpers_day_26_exercise.Models;

namespace taghelpers_day_26_exercise.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Employee model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Registration Successful!";
                return View (model);
            }

            return View(model);
        }
        
    }
}
