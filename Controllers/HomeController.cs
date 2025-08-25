using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Note.Data;
using Note.Entities;
using Note.Models;

namespace Note.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public readonly MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [Route("Notlarım")]
    public IActionResult Index()
    {
        var notes = _context.UserNote
        .Include(us => us.Users)
        .Include(us=> us.Notes)
        .Where(us => us.IsActive == true)
        .Select(us => new UsersNotesViewModel
        {
            FullName = us.Users!.FullName,
            NoteId = us.Notes!.Id,
            NoteName = us.Notes.Name,
            NoteDesc = us.Notes.Description
            

        })
        .ToList();
        // var userId = HttpContext.Session.GetInt32("Usersid");
        // if (userId == null)
        //     return RedirectToAction("Login","Login");

        return View(notes);
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
