using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Publisher name is required")]
        [StringLength(100)]
        [Display(Name = "Publisher Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Country")]
        public string Country { get; set; } = "United States";

        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Phone]
        [Display(Name = "Phone")]
        public string? Phone { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Total Books")]
        public int TotalBooks { get; set; } = 1;

        [Display(Name = "Established Year")]
        public int EstablishedYear { get; set; } = 2000;
    }
}
