using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;

        [Required]
        public string Director { get; set; } = null!;
    }
}