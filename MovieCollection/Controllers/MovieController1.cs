using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCollection.Data;
using MovieCollection.Models;
using MovieCollection.ViewModels;


public class MoviesController : Controller
{
    private readonly ApplicationDbContext _context;

    public MoviesController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var movies = await _context.Movies
            .Include(m => m.Genre)
            .Include(m => m.Director)
            .ToListAsync();

        return View(movies);
    }
    public async Task<IActionResult> Details(int id)
    {
        var movie = await _context.Movies
            .Include(m => m.Genre)
            .Include(m => m.Director)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
            return NotFound();

        return View(movie);
    }
    public async Task<IActionResult> Create()
    {
        var viewModel = new MovieFormViewModel
        {
            Genres = await _context.Genres.ToListAsync(),
            Directors = await _context.Directors.ToListAsync()
        };

        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MovieFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Genres = await _context.Genres.ToListAsync();
            viewModel.Directors = await _context.Directors.ToListAsync();
            return View(viewModel);
        }

        _context.Movies.Add(viewModel.Movie);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie == null)
            return NotFound();

        var viewModel = new MovieFormViewModel
        {
            Movie = movie,
            Genres = await _context.Genres.ToListAsync(),
            Directors = await _context.Directors.ToListAsync()
        };

        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MovieFormViewModel viewModel)
    {
        if (id != viewModel.Movie.Id)
            return NotFound();

        if (!ModelState.IsValid)
        {
            viewModel.Genres = await _context.Genres.ToListAsync();
            viewModel.Directors = await _context.Directors.ToListAsync();
            return View(viewModel);
        }

        _context.Movies.Update(viewModel.Movie);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        var movie = await _context.Movies
            .Include(m => m.Genre)
            .Include(m => m.Director)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
            return NotFound();

        return View(movie);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie == null)
            return NotFound();

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}

