using System.ComponentModel.DataAnnotations;
using static Gym.Infrastructure.Constants.DataConstant.ApplicationUser;
namespace Gym.Core.Models.User
{
    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

   
        [Required]
        [StringLength(MaxLengthPassword, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = MinLengthPassword)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        [StringLength(MaxLengthFirstName,MinimumLength = MinLengthFirstName)]
        public string FirstName { get; set; } = string.Empty;


        [Required]
        [StringLength(MaxLengthLastName, MinimumLength = MinLengthLastName)]
        public string LastName { get; set; } = string.Empty;
    }
}
