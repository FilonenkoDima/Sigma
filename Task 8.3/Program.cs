using System.Linq;

namespace Task83
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Product> products1 = new List<Product>()
            {
                new Product("Chicken", 10.5d, 1d),
                new Product("Apple", 1.5d, 2d),
                new Product("Meat", 20.5d, 3.1d),
                new Product("Bananas", 1.7d, 0.8d),
            };

            List<Product> products2 = new List<Product>()
            {
                new Product("Lamb", 10.5d, 1d),
                new Product("Apple", 1.5d, 2d),
                new Product("Meat", 20.5d, 3.1d),
                new Product("Bananas", 1.7d, 0.8d),
            };
            Storage s1 = new Storage(products1);
            Storage s2 = new Storage(products2);


            Console.WriteLine(s2.Except(s1));

            Console.WriteLine(s2.Intersect(s1));

            Console.WriteLine(s2.Union(s1));


        }

    }
}



