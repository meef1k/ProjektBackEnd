using System.ComponentModel.DataAnnotations;

namespace Spedition.ViewModel
{
    public class RegisterVM
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string EmailAddress { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$&_/\*]).{6,18}", ErrorMessage = "Password requires minimum 6 characters, 1 lowercase letter, 1 uppercase letter, 1 number and 1 special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm your password")]
        [Required(ErrorMessage = "Confirm your password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password are not the same")]
        public string ConfirmPassword { get; set; }
    }
}
