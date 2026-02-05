using MovieCollection.Models;

namespace MovieCollection.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; } = new Movie();

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();

        public IEnumerable<Director> Directors { get; set; } = new List<Director>();
    }
}