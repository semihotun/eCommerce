using System.ComponentModel.DataAnnotations;
namespace Entities.ViewModels.WebViewModel.IdentityAccount
{
    public class RegisterViewModel
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(60)]
        public string Surname { get; set; }
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
