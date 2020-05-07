using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodGenerator
{
    public enum FoodType { Breakfast, Snack, Lunch, Dinner };
    public class Food : Type
    {
        public FoodType Typ { get; set; }

        public string Name { get; set; }

        public string[] Ingredients { get; set; }

        public string Reciepe { get; set; }

        public int CaloryCount { get; set; }

        public static Food Create(FoodType FoodType, string name, string[] ingredients, string reciepe, int calorycount)
        {
            Food food = new Food();
            food.Typ = FoodType;
            food.Name = name;
            food.Ingredients = ingredients;
            food.Reciepe = reciepe;
            food.CaloryCount = calorycount;

            return food;
        }

    }
}