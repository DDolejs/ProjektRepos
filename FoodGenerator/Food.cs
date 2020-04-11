using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodGenerator
{
    public enum typ { Breakfast, Snack, Lunch, Dinner };
    public class Food : Type
    {
        public typ Typ { get; set; }

        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string Reciepe { get; set; }

        public static Food Create(typ typ, string name, string ingredients, string reciepe)
        {
            Food food = new Food();
            food.Typ = typ;
            food.Name = name;
            food.Ingredients = ingredients;
            food.Reciepe = reciepe;

            return food;
        }

    }
}