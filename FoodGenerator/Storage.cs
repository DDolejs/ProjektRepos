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
        //metoda pro random hledání
        public Food FindRandomFiltered(FoodType foodType)
        {
            Random ran = new Random();
            List<Food> search = findByType(foodType);
            int index = ran.Next(search.Count);

            return search[index];

        }
        //vyfiltorvat podle typu 
        public List<Food> findByType(FoodType foodType)
        {
            List<Food> results = new List<Food>();

            foreach (Food food in Foods)
            {
                if (food.Typ == foodType)
                {
                    results.Add(food);
                }
            }

            return results;
        }
    }

}
        //pak random z toho listu results - done
        //vyfiltorvat podle typu - done
        //formular pro pridavani >> possible feature
    


