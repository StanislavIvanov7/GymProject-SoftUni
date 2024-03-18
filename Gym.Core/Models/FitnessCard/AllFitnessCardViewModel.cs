namespace Gym.Core.Models.FitnessCard
{
    public class AllFitnessCardViewModel
    {

        public int Id { get; set; }
        
        public string FitnessCardCategory { get; set; } = null!;
 
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;
     
        public string ImageUrl { get; set; } = string.Empty;

        public string Creator { get; set; } = null!;

       
    }
}
