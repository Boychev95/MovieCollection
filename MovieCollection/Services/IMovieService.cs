using MovieCollection.Models;

namespace MovieCollection.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task CreateAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(int id);
    }
}
