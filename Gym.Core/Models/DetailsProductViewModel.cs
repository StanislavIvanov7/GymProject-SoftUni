namespace Gym.Core.Models
{
    public class DetailsProductViewModel
    {
        
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ProductCategory { get; set; } = string.Empty;

        public string CreatorName { get; set; } = string.Empty;

        public string CreatorEmail { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public int Quantity { get; set; }


    }
}
