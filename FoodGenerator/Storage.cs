using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodGenerator
{
    public class Storage
    {
        public List<Food> Foods;
        public Storage() 
        {
            Foods = new List<Food>();
        }
        //metoda pro filtr podle typů
        public List<Food> FindByType(typ foodType)
        {
            List<Food> results = new List<Food>();

            foreach (Food food in Foods)
            {
                if (food.FoodType == foodType)
                {
                    results.Add(food);
                }
            }

            return results;
        }//pak random z toho listu results
        //vyfiltorvat podle typu 
        //formular pro pridavani >> possible feature
    }

}
