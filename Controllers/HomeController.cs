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
        var userId = HttpContext.Session.GetInt32("Usersid");
        var notes = _context.UserNote
        .Include(us => us.Users)
        .Include(us => us.Notes)
        .Where(us => us.IsActive == true)
        // .Where(us => us.Users!.Id == userId)
        .Select(us => new UsersNotesViewModel
        {
            FullName = us.Users!.FullName,
            NoteId = us.Notes!.Id,
            NoteName = us.Notes.Name,
            NoteDesc = us.Notes.Description
            

        })
        .ToList();
        
        // if (userId == null)
        //     return RedirectToAction("Login","Login");
        
        return View(notes);
    }
    public IActionResult Login()
    {
        return View();
    }

    [Route("Edit/{id}")]
    public IActionResult Edit(int id)
    {
        var note = _context.Notes.Find(id);
        if (note == null) return NotFound();

        var vm = new NoteEditViewModel
        {
            Id = note.Id,
            Name = note.Name,
            Description = note.Description,
            IsActive = true,
            IsDelete = false,
            CreateTime = DateTime.Now
        };
        return View(vm);
    }

    [Route("Edit/{id}")]
    [HttpPost]
    public IActionResult Edit(NoteEditViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var note = _context.Notes.Find(model.Id);
        if (note == null) return NotFound();

        note.Name = model.Name;
        note.Description = model.Description;
        note.CreateTime = DateTime.Now;
        note.IsActive = true;
        note.IsDelete = false;
        
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [Route("Notes/Delete/{id}")]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var note = _context.Notes.Find(id);
        if (note == null) return NotFound();
        note.IsActive = false;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
