using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RepositoryWithMVC.Repository;
using repo_demo.Models;
namespace RepositoryWithMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        // public EmployeeController(Models.EmployeeContext context)
        // {
        //     employeeRepository = new EmployeeRepository(context);
        // }
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ActionResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }
        public ActionResult AddEmployee()
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Add Employee Failed";
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                int result = _employeeRepository.AddEmployee(model);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    TempData["Failed"] = "Failed";
                    return RedirectToAction("AddEmployee", "Employee");
                }
            }
            return View();
        }
        public ActionResult EditEmployee(int employeeId)
        {

            if (TempData["Failed"] != null)

            {
                ViewBag.Failed = "Edit Employee Failed";
            }
            Employee model = _employeeRepository.GetEmployeeById(employeeId);
            return View(model);

        }
        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                int result = _employeeRepository.UpdateEmployee(model);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Employee");

                }
                else
                {
                    return RedirectToAction("Index", "Employee");
                }
            }
            return View();
        }
        
             }
             } 