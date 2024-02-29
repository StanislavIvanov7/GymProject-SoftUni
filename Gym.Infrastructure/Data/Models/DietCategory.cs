using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Gym.Infrastructure.Constants.DataConstant.DietCategory;

namespace Gym.Infrastructure.Data.Models
{
    [Comment("Diet category table")]
    public class DietCategory
    {
        [Key]
        [Comment("Diet category identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxLengthName)]
        [Comment("Diet category name")]
        public string Name { get; set; } = string.Empty;


        public ICollection<Diet> Diets { get; set; } = new List<Diet>();
    }
}