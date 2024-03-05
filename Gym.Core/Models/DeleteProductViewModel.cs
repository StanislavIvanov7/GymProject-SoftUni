using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Models
{
    public class DeleteProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
