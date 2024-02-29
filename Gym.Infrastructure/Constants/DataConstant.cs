using System;
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

            public const int MaxLengthDescription = 200;
            public const int MinLengthDescription = 10;

            public const int MaxLengthImageUrl = 2048;
            public const int MinLengthImageUrl = 10;
        }

        public static class FoodItemCategory
        {
            public const int MaxLengthName = 100;
            public const int MinLengthName = 3;
        }
    }
}
