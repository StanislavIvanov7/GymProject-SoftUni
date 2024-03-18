namespace Gym.Core.Models.WorkoutPlan
{
    public class DetailsWorkoutPlanViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string WorkoutPlanCategory { get; set; } = string.Empty;

        public string Creator { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
