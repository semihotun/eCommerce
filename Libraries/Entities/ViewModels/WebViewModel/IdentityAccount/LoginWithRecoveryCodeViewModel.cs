using System.ComponentModel.DataAnnotations;
namespace Entities.ViewModels.WebViewModel.IdentityAccount
{
    public class LoginWithRecoveryCodeViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Recovery Code")]
        public string RecoveryCode { get; set; }
    }
}
