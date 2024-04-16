using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Gym.Infrastructure.Constants.DataConstant.ApplicationUser;
namespace Gym.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [MaxLength(MaxLengthFirstName)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthLastName)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;

    }
}
