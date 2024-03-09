﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gym.Core.Constants.MessageConstants;
using static Gym.Infrastructure.Constants.DataConstant.FitnessCard;

namespace Gym.Core.Models.FitnessCard
{
    public class FitnessCardFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
             MinLengthPrice,
             MaxLengthPrice,
             ConvertValueInInvariantCulture = true,
             ErrorMessage = "Price per month must be a positive number and less than {2} leva")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthDescription, MinimumLength = MinLengthDescription, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public int FitnessCardCategoryId { get; set; }


        public IEnumerable<FitnessCardCategoryViewModel> FitnessCardCategories { get; set; }
            = new List<FitnessCardCategoryViewModel>();


        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthImageUrl, MinimumLength = MinLengthImageUrl, ErrorMessage = LengthMessage)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}