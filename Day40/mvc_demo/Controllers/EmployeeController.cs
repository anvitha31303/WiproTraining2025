using Microsoft.AspNetCore.Mvc;
using mvc_demo.Models;

namespace mvc_demo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult details()
        {
            Employee e1 = new Employee
            {
                empid = 101,
                firstname = "hello",
                lastname = "jack",
                city="Chennai"

            };
            return View(e1);
        }
        public IActionResult viewdemo()
        {
            Employee e1 = new Employee
            {
                empid = 101,
                firstname = "hello",
                lastname = "jack",
                city = "Chennai"

            };
            return View(e1);
        }
        public IActionResult create_employee()
        {
            return View();
        }
    }
}
