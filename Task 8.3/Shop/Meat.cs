using System;
using System.Collections.Generic;
using System.Text;

namespace Task83
{
    enum Category { Highest, First, Second }
    enum MeatType { Lamb, Veal, Pork, Chicken }
    class Meat : Product
    {

        public Category CategoryOfMeat { get; }
        public MeatType TypeOfMeat { get; }
        public Meat(Category c, MeatType t, string name, double price, double weight) :
           base(name, price, weight)
        {
            CategoryOfMeat = c;
            TypeOfMeat = t;
        }

        public Meat(string category, string type, string name, double price, double weight) :
           base(name, price, weight)
        {

            if (Enum.IsDefined(typeof(Category), category) && Enum.IsDefined(typeof(MeatType), type))
            {
                CategoryOfMeat = Enum.Parse<Category>(category);
                TypeOfMeat = Enum.Parse<MeatType>(type);
            }
            else
            {
                throw new Exception("invalid CategoryOfMeat or TypeOfMeat");
            }

        }

        public override double ChangePrice(double percent)
        {
            double temp;
            switch (CategoryOfMeat)
            {
                case Category.Highest:
                    temp = 30;
                    break;
                case Category.First:
                    temp = 20;
                    break;
                case Category.Second:
                    temp = 10;
                    break;

                default:
                    temp = 0;
                    break;
            }

            Price += Price * (percent + temp) / 100; ;
            return Price;
        }
    }
}