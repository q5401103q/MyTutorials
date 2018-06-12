using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Builder.Implement02
{
    public class ProductBBuilder : IProductBuilder
    {
        private Product product;

        public ProductBBuilder()
        {
            product = new Product();
        }

        public void BuildAttribute1()
        {
            product._attribute1 = 6;
        }

        public void BuildAttribute2()
        {
            product._attribute2 = (decimal)5;
        }

        public void BuildAttribute3()
        {
            product._attribute3 = 4d;
        }

        public void BuildAttribute4()
        {
            product._attribute4 = "Product B";
        }

        public void BuildAttribute5()
        {
            product._attribute5 = DateTime.Now.AddMinutes(10);
        }

        public void BuildAttribute6()
        {
            product._attribute6 = new KeyValuePair<string,float>("B",1f);
        }

        public Product Build()
        {
            return product;
        }
    }
}
