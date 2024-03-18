namespace Gym.Core.Models.FitnessCard
{
    public class DetailsFitnessCardViewModel
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public string FitnessCardCategory { get; set; } = string.Empty;

        public string Creator { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int DurationInMoths { get; set; } 

        public string IssuesDate { get; set; } = string.Empty;

       
    }
}
