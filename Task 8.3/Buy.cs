using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task83
{
    class Buy
    {
        Product product { get; }
        private int count;

        public int Count
        {
            get { return count; }
            set
            {
                if (value > 0)
                    count = value;
                else
                    count = 0;
            }
        }


        private double countWeight;

        public double CountWeight
        {
            get { return countWeight; }
            private set { countWeight = Count * product.Weight; }
        }

        private double countPrice;

        public double CountPrice
        {
            get { return countPrice; }
            set { countPrice = Count * product.Price; }
        }

        public Buy(Product product, int Count)
        {
            this.product = product;
            this.Count = Count;
        }

        public Buy() : this(default, default)
        {

        }
        #region task 8.3
        public override bool Equals(object obj)
        {
            return obj is Buy buy &&
                   product.Equals(buy.product);
        }
        public override int GetHashCode()
        {
            return product.GetHashCode();
        }
        #endregion
        public override string? ToString()
        {
            return $"Count: {Count}, Count price: {CountPrice}, Count weight: {CountWeight}";
        }
    }


}
