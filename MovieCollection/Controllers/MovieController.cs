using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCollection.Data;
using MovieCollection.Models;
using MovieCollection.Services;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;
    private readonly ApplicationDbContext _context;

    public MoviesController(IMovieService movieService, ApplicationDbContext context)
    {
        _movieService = movieService;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var movies = await _movieService.GetAllAsync();
        return View(movies);
    }

    public async Task<IActionResult> Details(int id)
    {
        var movie = await _movieService.GetByIdAsync(id);

        if (movie == null)
            return NotFound();

        return View(movie);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "Id", "Name");
            return View(movie);
        }

        await _movieService.CreateAsync(movie);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _movieService.GetByIdAsync(id);

        if (movie == null)
            return NotFound();

        ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "Id", "Name", movie.GenreId);
        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Movie movie)
    {
        if (id != movie.Id)
            return NotFound();

        if (!ModelState.IsValid)
        {
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "Id", "Name", movie.GenreId);
            return View(movie);
        }

        await _movieService.UpdateAsync(movie);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var movie = await _movieService.GetByIdAsync(id);

        if (movie == null)
            return NotFound();

        return View(movie);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _movieService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}