using databasedemo_efcore.Models;
using Microsoft.AspNetCore.Mvc;
namespace databasedemo_efcore.Models;

public class EmployeeController : Controller
{
    private readonly CompanyContext _context;
    public EmployeeController(CompanyContext context)
    {
        _context = context;
    }
    //crud operations on employee table/model
    //read
    // public IActionResult Index()
    // {
    //     var employees = _context.Employee.ToList();
    //     return View(employees);
    // }
    //create
    [HttpPost]
    public IActionResult Create(Employee employee)
    {
    _context.Employees.Add(employee);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
 
    // update
    // [HttpPost]
    // public IActionResult Edit(Employee employee)
    // {
    //     _context.Employees.Update(employee);
    //     _context.SaveChanges();
    //     return RedirectToAction("Index");
    // }
    // delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}

