using System.ComponentModel.DataAnnotations;
namespace Entities.ViewModels.WebViewModel.IdentityAccount
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
