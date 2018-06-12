using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Builder.Implement01
{
    public class ProductBuilder
    {
        private Product product;

        public ProductBuilder()
        {
            product = new Product();
        }

        public ProductBuilder Attribute1(int attribute1)
        {
            product._attribute1 = attribute1;
            return this;
        }

        public ProductBuilder Attribute2(decimal attribute2)
        {
            product._attribute2 = attribute2;
            return this;
        }

        public ProductBuilder Attribute3(double attribute3)
        {
            product._attribute3 = attribute3;
            return this;
        }

        public ProductBuilder Attribute4(string attribute4)
        {
            product._attribute4 = attribute4;
            return this;
        }

        public ProductBuilder Attribute5(DateTime attribute5)
        {
            product._attribute5 = attribute5;
            return this;
        }

        public ProductBuilder Attribute6(KeyValuePair<string, float> attribute6)
        {
            product._attribute6 = attribute6;
            return this;
        }

        public Product Build()
        {
            return product;
        }
    }
}
