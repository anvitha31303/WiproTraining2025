using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvc_taghelpers_day_26.Models;
using MyMvcProjectSession.Models;
using System.Diagnostics;

namespace MyMvcProjectSession.Controllers;

public class HomeController : Controller
{
    // private readonly ILogger<HomeController> _logger;


    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }

    //sessions demo
    private const string SessionName = "_Name";
    private const string SessionAge = "_Age";

    public IActionResult Index()
    {
        HttpContext.Session.SetString(SessionName, "Rajesh");
        HttpContext.Session.SetInt32(SessionAge, 23);
        return View();
    }

    public IActionResult About()
    {
        ViewBag.name = HttpContext.Session.GetString(SessionName);
        ViewBag.Age = HttpContext.Session.getInt32(SessionAge);

        ViewData["Message"] = "ASP.NET Core!";
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Message"] = "Your contact page";
        return View();
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}