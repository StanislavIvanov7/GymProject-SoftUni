using Gym.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Models
{
    public class DetailsProductViewModel
    {
        
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ProductCategory { get; set; } = string.Empty;

        public string Creator { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

       
    }
}
