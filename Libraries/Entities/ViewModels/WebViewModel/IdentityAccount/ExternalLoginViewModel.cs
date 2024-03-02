using System.ComponentModel.DataAnnotations;
namespace Entities.ViewModels.WebViewModel.IdentityAccount
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
