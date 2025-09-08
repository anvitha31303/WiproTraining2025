using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ajax_demo.Models;

namespace ajax_demo.Controllers;

public class StudentController : Controller
{
    private readonly StudentContext _context;

    public StudentController(StudentContext context)
    {
        _context = context;
    }
  public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult createStudent(Student std)
    {
        _context.Students.Add(std);
_context.SaveChanges();

        string message = "SUCCESS";
        return Json(new { Message = message });

    }
    public JsonResult getStudent(string id)
    {
        List<Student> students = new List<Student>();
        students = _context.Students.ToList();

        return Json(students);

    }
    
}