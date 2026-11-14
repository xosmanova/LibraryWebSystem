using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "Membership Type")]
        public string MembershipType { get; set; } = "Student"; // Student, Faculty, Standard, Premium

        [Display(Name = "Books Borrowed")]
        public int BooksBorrowed { get; set; } = 0;

        [Display(Name = "Status")]
        public string Status { get; set; } = "Active"; // Active, Suspended

        [Display(Name = "Joined Date")]
        public DateTime JoinedDate { get; set; } = DateTime.Now;

        [Display(Name = "Avatar")]
        public string? AvatarUrl { get; set; }
    }
}
