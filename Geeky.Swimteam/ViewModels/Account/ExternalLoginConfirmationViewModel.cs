using System.ComponentModel.DataAnnotations;

namespace Geeky.Swimteam.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
