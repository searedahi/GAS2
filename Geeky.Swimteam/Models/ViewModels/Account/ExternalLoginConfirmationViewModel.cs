using System.ComponentModel.DataAnnotations;

namespace Geeky.Swimteam.Models.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
