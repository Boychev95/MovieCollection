using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }

        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        [Required]
        public int DirectorId { get; set; }
        public Director Director { get; set; } = null!;
    }
}