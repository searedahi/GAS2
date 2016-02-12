using System.ComponentModel.DataAnnotations;

namespace Geeky.Swimteam.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
