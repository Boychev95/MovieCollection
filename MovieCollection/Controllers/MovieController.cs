using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCollection.Data;
using MovieCollection.Services;
using MovieCollection.ViewModels;

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

        await _movieService.CreateAsync(viewModel.Movie);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _movieService.GetByIdAsync(id);

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

        await _movieService.UpdateAsync(viewModel.Movie);

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