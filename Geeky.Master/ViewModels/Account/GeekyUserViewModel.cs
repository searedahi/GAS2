using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Mvc;

namespace Geeky.Master.ViewModels.Account
{
    public class GeekyUserEditViewModel
    {
        public virtual string Id { get; set; }
        public virtual string ConcurrencyStamp { get; set; }

        [Required]
        [EmailAddress]
        [Remote("EmailEditAvailable", "Account", AdditionalFields = "Id", ErrorMessage = "Email already in use.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Remote("UserNameEditAvailable", "Account", AdditionalFields = "Id", ErrorMessage = "Username already in use.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class GeekyUserCreateViewModel
    {
        public virtual string Id { get; set; }
        public virtual string ConcurrencyStamp { get; set; }

        [Required]
        [EmailAddress]
        [Remote("EmailAvailable", "Account", ErrorMessage = "Email already in use.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Remote("UserNameAvailable", "Account", ErrorMessage = "Username already in use.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}