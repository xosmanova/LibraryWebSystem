using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        [StringLength(100)]
        [Display(Name = "Author Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Biography")]
        public string? Biography { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; } = "United States";

        [Display(Name = "Books Count")]
        public int BooksCount { get; set; } = 1;

        [Display(Name = "Popular Genre")]
        public string PopularGenre { get; set; } = "Novels";

        [Display(Name = "Avatar URL")]
        public string? AvatarUrl { get; set; }
    }
}
