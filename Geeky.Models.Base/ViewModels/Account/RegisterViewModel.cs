using System.ComponentModel.DataAnnotations;

namespace Geeky.Models.Base.ViewModels.Account
{
    //[Validator(typeof(RegisterViewModelValidator))]
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }


    //public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    //{
    //    public RegisterViewModelValidator()
    //    {
    //        RuleFor(x => x.Name).NotEmpty().WithMessage("Place Name is required").Length(0, 100);
    //        RuleFor(x => x.Url).Must(BeUniqueUrl).WithMessage("Url already exists");
    //    }

    //    private bool BeUniqueUrl(string url)
    //    {
    //        var _db = new DataContext();
    //        if (_db.Places.SingleOrDefault(x => x.Url == url) == null) return true;
    //        return false;
    //    }
    //}

}
