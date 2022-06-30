using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    public class Dish : IEnumerable
    {
        public string NameOfTheDish { get; private set; }
        private Dictionary<string,decimal> ingredients { get; set; }
        public Dish()
        {

        }

        public Dish(string nameOfTheDish, Dictionary<string, decimal> ingredients)
        {
            NameOfTheDish = nameOfTheDish;
            this.ingredients = new Dictionary<string, decimal>(ingredients);
        }

        public IEnumerator GetEnumerator()
        {
            return ingredients.GetEnumerator();
        }

        public decimal this[string key]
        {
            get
            {
                return ingredients[key];
            }
        }

        public override string ToString()
        {
            string result = $"{NameOfTheDish}\n";
            foreach (var item in ingredients)
            {
                result += $"{item.Key} - {item.Value}\n";
            }
            return result;
        }
    }
}
