using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task83
{
    public class Product 
    {
        public string Name { get; set; }
        private double price;

        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
                else
                    price = 0;
            }
        }

        private double weight;

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                    weight = value;
                else
                    weight = 0;
            }
        }

        public Product() : this(default, default, default)
        {

        }
        public Product(string Name, double Price, double Weight)
        {
            this.Name = Name;
            this.Price = Price;
            this.Weight = Weight;
        }

        public virtual double ChangePrice(double percent)
        {
            this.Price += this.Price * percent / 100;
            return Price;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}, Weight: {Weight}";
        }

        #region task 8.3
        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Name == product.Name &&
                   Price == product.Price &&
                   Weight == product.Weight;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price, Weight);
        }
        #endregion
    }
}
