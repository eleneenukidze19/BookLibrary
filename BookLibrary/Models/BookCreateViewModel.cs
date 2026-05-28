using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class BookCreateViewModel
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [Range(1000, 2100)]
        public int Year { get; set; }

        [MinLength(1, ErrorMessage = "Please select at least one genre.")]
        public List<int> SelectedGenreIds { get; set; } = new();

        public List<Genre> AllGenres { get; set; } = new();
    }
}
