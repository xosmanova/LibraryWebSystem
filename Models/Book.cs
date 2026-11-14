using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book title is required")]
        [StringLength(150, ErrorMessage = "Book title cannot exceed 150 characters")]
        [Display(Name = "Book Name")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Alternate Title")]
        [StringLength(150)]
        public string? AlternateTitle { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters")]
        [Display(Name = "Author")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        [StringLength(80)]
        [Display(Name = "Category")]
        public string Category { get; set; } = string.Empty;

        [StringLength(100)]
        [Display(Name = "Publisher")]
        public string? Publisher { get; set; }

        [StringLength(50)]
        [Display(Name = "Language")]
        public string? Language { get; set; } = "English";

        [Required(ErrorMessage = "Available copies count is required")]
        [Range(0, 5000, ErrorMessage = "Copies count must be between 0 and 5000")]
        [Display(Name = "Copies Available")]
        public int CopiesAvailable { get; set; } = 1;

        [Range(0, 100000, ErrorMessage = "Price must be a valid number")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Price (₼)")]
        public decimal Price { get; set; } = 0;

        [Display(Name = "Status")]
        public string Status { get; set; } = "Available"; // Available, Issued, Reserved, Overdue

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Description")]
        [StringLength(1000)]
        public string? Description { get; set; }

        [Display(Name = "Cover Image URL")]
        public string? CoverImageUrl { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
