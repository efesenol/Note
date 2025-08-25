using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Note.Models;

namespace Note.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("Notlarım")]
    public IActionResult Index()
    {
        // var userId = HttpContext.Session.GetInt32("Usersid");
        // if (userId == null)
        //     return RedirectToAction("Login","Login");

        return View();
    }
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
