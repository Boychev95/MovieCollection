using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCollection.Data;
using MovieCollection.Models;

public class GenresController : Controller
{
    private readonly ApplicationDbContext _context;

    public GenresController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var genres = await _context.Genres.ToListAsync();
        return View(genres);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Genre genre)
    {
        if (!ModelState.IsValid)
        {
            return View(genre);
        }

        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

}