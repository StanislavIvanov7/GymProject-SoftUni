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
using static Gym.Infrastructure.Constants.DataConstant.Product;
using static Gym.Core.Constants.MessageConstants;
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
