namespace Gym.Core.Models.Diet
{
    public class DetailsDietViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string DietCategory { get; set; } = string.Empty;

        public string Creator { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
