using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    public class Menu : IEnumerable
    {
        private List<Dish> menu { get; set; }
        public Menu()
        {

        }
        public Menu(List<Dish> dishes)
        {
            this.menu = new List<Dish>(dishes);
        }

        public Dish this[int index]
        {
            get
            {
                return menu[index];
            }
        }

        public Menu(string fileName)
        {
            menu = new List<Dish>();
            string text = File.ReadAllText(fileName);
            List<string> dishes = text.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var item in dishes)
            {
                Dictionary<string, decimal> dict = new Dictionary<string, decimal>();
                List<string> dish = item.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (string line in dish.Skip(1))
                {
                    List<string> product = line.Split(" - " , StringSplitOptions.RemoveEmptyEntries).ToList();
                    dict.Add(product[0], decimal.Parse(product[1]));
                }
                menu.Add(new Dish(dish[0], dict));
            }
        }
        public IEnumerator GetEnumerator()
        {
            return menu.GetEnumerator();
        }
        public override string ToString()
        {
            string result = "";
            foreach (var dish in menu)
                result += dish;
            return result;
        }

    }
}
