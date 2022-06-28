using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Task83
{
    public class Storage
    {
        #region task 2
        public List<Product> Product_storage { get; }

        public Storage(List<Product> products)
        {
            Product_storage = new List<Product>();
            foreach (var item in products)
                Product_storage.Add(item);
        }
        public Storage()
        {
            Product_storage = new List<Product>();
        }
        public void UserInput()
        {
            string? name, category = "", type = "", expiring;
            double price, weight;

            Console.WriteLine("Enter product data:");
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Price: ");
            price = double.Parse(Console.ReadLine());
            Console.Write("Weight: ");
            weight = double.Parse(Console.ReadLine());
            Console.WriteLine("(Dairy product)Expire data: ");
            expiring = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(expiring))
            {
                Console.WriteLine("(Meat) Category = ");
                category = Console.ReadLine();
                Console.WriteLine("(Meat) Meat Type = ");
                type = Console.ReadLine();
            }

            Product p;
            if (!String.IsNullOrWhiteSpace(expiring))
                p = new DairyProducts(int.Parse(expiring), name, price, weight);
            else if (!String.IsNullOrWhiteSpace(category) && !String.IsNullOrWhiteSpace(type))
                p = new Meat(category, type, name, price, weight);
            else
                p = new Product(name, price, weight);

            Product_storage.Add(p);
        }

        public void FindMeat()
        {
            Console.WriteLine("\tOnly meat");
            foreach (var item in Product_storage)
            {
                if (item is Meat)
                    Check.Output(item);
            }
        }
        public void ChangePrice(double percent)
        {
            foreach (var item in Product_storage)
                item.ChangePrice(percent);
        }

        public Product this[int index]
        {
            get
            {
                if (index >= 0 && index < Product_storage.Count)
                {
                    return Product_storage[index];
                }
                else
                {
                    throw new Exception("Index out of range array");
                }
            }
            set
            {
                Product_storage[index] = value;
            }
        }


        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Product_storage.Count; i++)
            {
                result += Product_storage[i].ToString() + "\n";
            }
            return result;
        }
        #endregion

        #region task7
        public void ParseFromFile()
        {
            ParseFromFile(new FileReader());
        }
        public void ParseFromFile(FileReader fileReader)
        {
            var dataFromFile = fileReader.ReadLinesFromFileToList();


            string name = dataFromFile[0];
            if (char.IsLower(name[0]))
                name = char.ToUpper(name[0]) + name.Substring(1);
            double price = 0, weight = 0;

            if (double.TryParse(dataFromFile[1], NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out double pr))
                price = pr;
            if (double.TryParse(dataFromFile[2], NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out double wh))
                weight = wh;

            string categoryORexpiring = dataFromFile[3];
            string type = dataFromFile[4];


            if (name != null && dataFromFile[1] != null && dataFromFile[2] != null)
            {
                Product p;
                try
                {
                    if (int.TryParse(categoryORexpiring, out int ex))
                        p = new DairyProducts(ex, name, price, weight);
                    else if (categoryORexpiring != null && type != null)
                        p = new Meat(categoryORexpiring, type, name, price, weight);
                    else
                        p = new Product(name, price, weight);

                    Product_storage.Add(p);
                }
                catch (Exception e)
                {
                    fileReader.AddLog(e.Message);
                }

            }

        }

        public void OutputLogs()
        {
            OutputLogs(new FileReader());
        }
        public void OutputLogs(FileReader fileReader)
        {
            Console.WriteLine(fileReader.LogToString());
        }

        #endregion

        #region task 8.3
        public Storage Intersect(in Storage other)
        {
            if (this == null || other == null)
            {
                throw new ArgumentNullException("No data given");
            }
            return new Storage(Product_storage.Intersect(other.Product_storage).ToList()); ;
        }
        public Storage Union(in Storage other)
        {
            if (this == null && other == null)
            {
                throw new ArgumentNullException("No data given");
            }
            else if (this == null)
            {
                return other;
            }
            else if (other == null)
            {
                return this;
            }
            return new Storage(Product_storage.Union(other.Product_storage).ToList());
        }
        public Storage Except(in Storage other)
        {
            if (this == null)
            {
                throw new ArgumentNullException("No data given");
            }
            else if (other == null)
            {
                return this;
            }
            return new Storage(Product_storage.Except(other.Product_storage).ToList());
        }
        public override bool Equals(object obj)
        {
            return obj is Storage storage &&
                   Product_storage.Equals(storage.Product_storage);
        }
        public override int GetHashCode()
        {
            return Product_storage.GetHashCode();
        }
        #endregion
    }
}