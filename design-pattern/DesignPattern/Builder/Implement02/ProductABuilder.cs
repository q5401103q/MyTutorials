using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Builder.Implement02
{
    public class ProductABuilder : IProductBuilder
    {
        private Product product;

        public ProductABuilder()
        {
            product = new Product();
        }

        public void BuildAttribute1()
        {
            product._attribute1 = 1;
        }

        public void BuildAttribute2()
        {
            product._attribute2 = (decimal)2;
        }

        public void BuildAttribute3()
        {
            product._attribute3 = 3d;
        }

        public void BuildAttribute4()
        {
            product._attribute4 = "Product A";
        }

        public void BuildAttribute5()
        {
            product._attribute5 = DateTime.Now;
        }

        public void BuildAttribute6()
        {
            product._attribute6 = new KeyValuePair<string, float>("A", 6f);
        }

        public Product Build()
        {
            return product;
        }
    }
}
