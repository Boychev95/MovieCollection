using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Models
{
    public class Director
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string FullName { get; set; } = string.Empty;

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
