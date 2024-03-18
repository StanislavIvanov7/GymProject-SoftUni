namespace Gym.Core.Models
{
    public class AllProductViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
       
        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Creator { get; set; } = null!;

        public int Quantity { get; set; }


    }
}
