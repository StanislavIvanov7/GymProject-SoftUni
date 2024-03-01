﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Infrastructure.Constants
{
    public static class DataConstant
    {
        public static class FoodItem
        {
            public const int MaxLengthName = 100;
            public const int MinLengthName = 3;

            public const int MaxLengthDescription = 500;
            public const int MinLengthDescription = 10;

            public const int MaxLengthImageUrl = 2048;
            public const int MinLengthImageUrl = 10;
        }

        public static class FoodItemCategory
        {
            public const int MaxLengthName = 100;
            public const int MinLengthName = 3;
        }

        public static class FitnessCard
        {
            public const int MaxLengthDescription = 500;
            public const int MinLengthDescription = 10;

            public const int MaxLengthImageUrl = 2048;
            public const int MinLengthImageUrl = 10;
        }

        public static class FitnessCardCategory
        {
            public const int MaxLengthName = 100;
            public const int MinLengthName = 3;
        }

        public static class Diet
        {
            public const int MaxLengthTitle = 75;
            public const int MinLengthTitle = 3;

            public const int MaxLengthDescription = 500;
            public const int MinLengthDescription = 10;

            public const int MaxLengthImageUrl = 2048;
            public const int MinLengthImageUrl = 10;
        }

        public static class DietCategory
        {
            public const int MaxLengthName = 100;
            public const int MinLengthName = 3;
        }

        public static class WorkoutPlan
        {
            public const int MaxLengthName = 100;
            public const int MinLengthName = 3 ;

            public const int MaxLengthDescription = 500;
            public const int MinLengthDescription = 10;

            public const int MaxLengthImageUrl = 2048;
            public const int MinLengthImageUrl = 10;
        }

        public static class WorkoutPlanCategory
        {
            public const int MaxLengthName = 100;
            public const int MinLengthName = 3;
        }
    }
}
