using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    static class MenuService
    {
        static public bool TryGetMenuPrice(Menu menu, PriceList priceList, Course course, out decimal total)
        {
            total = default;

            foreach (Dish item in menu)
            {
                if (!TryGetDishPrice(item, priceList, course, out decimal dishPrice))
                    return false;

                total += dishPrice;
            }
            total = Math.Round(total, 2);
            return true;
        }

        static public bool TryGetDishPrice(Dish dish, PriceList priceList, Course course, out decimal dishPrice)
        {
            dishPrice = default;
            foreach (KeyValuePair<string, decimal> item in dish)
            {
                if (!priceList.TryGetProductPrice(item.Key, out decimal productPrice))
                {
                    return false;
                }
                dishPrice += ((productPrice * item.Value / course[course.currency]) / 1000m);
                dishPrice = Math.Round(dishPrice, 2);
            }
            return true;
        }

        static public string GetDishes(Menu menu, PriceList priceList, Course course, out decimal total)
        {
            string result = "";
            total = default;
            foreach (Dish item in menu)
            {
                if (!TryGetDishPrice(item, priceList, course, out decimal dishPrice))
                    return result;

                total += dishPrice;
                result += $"{item.NameOfTheDish} : {course.currency} {Math.Round(dishPrice, 2)}\n";
            }
            return result;
        }
        static public Dictionary<string, decimal> GetProductsAmount(Menu menu)
        {
            Dictionary<string, decimal> amount = new Dictionary<string, decimal>();

            foreach (Dish item in menu)
                foreach (KeyValuePair<string, decimal> data in item)
                {
                    if (amount.ContainsKey(data.Key))
                        amount[data.Key] += data.Value;
                    else
                        amount.Add(data.Key, data.Value);
                }

            return amount;
        }
        static public Dictionary<string, decimal> GetProductsTotal(Menu menu, PriceList priceList, Course course)
        {
            Dictionary<string, decimal> products = GetProductsAmount(menu);
            Dictionary<string, decimal> productsTotal = new Dictionary<string, decimal>();

            foreach (var item in products)
                if (priceList.TryGetProductPrice(item.Key, out decimal productPrice))
                    productsTotal.Add(item.Key, Math.Round(item.Value * productPrice / course[course.currency] / 1000m, 2));
                
            return productsTotal;
        }
        static public string PrintProductCosts(Menu menu, PriceList priceList, Course course)
        {
            Dictionary<string, decimal> query = GetProductsAmount(menu);
            Dictionary<string, decimal> query1 = GetProductsTotal(menu, priceList, course);
            string result = "";

            foreach (KeyValuePair<string, decimal> item in query)
                result += $"Restaurant needs {item.Value} gram of {item.Key} for {course.currency} {query1[item.Key]}\n";

            return result;
        }
    }
}
