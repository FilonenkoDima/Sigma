using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class PriceList
    {
        private readonly Dictionary<string, decimal> prices;

        public PriceList()
        {
            prices = new Dictionary<string, decimal>();
        }

        public PriceList(in Dictionary<string, decimal> prices)
        {
            this.prices = new Dictionary<string, decimal>(prices);
        }

        public PriceList(string fileName)
        {
            prices = new Dictionary<string, decimal>();
            List<string> priceList = File.ReadAllLines(fileName).ToList();

            foreach (var item in priceList)
            {
                List<string> price = item.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToList();
                prices.Add(price[0].Trim(), decimal.Parse(price[1].Trim()));
            }
        }

        public bool TryGetProductPrice(string title, out decimal price)
        {
            try
            {
                if (!prices.TryGetValue(title, out price))
                {
                    throw new ArgumentException();
                }
                else
                {
                    return true;
                }
            }
            catch (ArgumentException)
            {
                if (!decimal.TryParse(Console.ReadLine(), out decimal productPrice))
                    throw;
                prices.Add(title, productPrice);
                price = productPrice;
                return true;
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (var item in prices)
            {
                result += $"{item.Key} - {item.Value}\n";
            }
            return result;
        }
    }
}
