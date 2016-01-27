using System.ComponentModel.DataAnnotations;

namespace Geeky.Models.Base.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
