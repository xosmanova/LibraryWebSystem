using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string Username { get; set; } = "admin";

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = "admin";

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; } = true;
    }
}
