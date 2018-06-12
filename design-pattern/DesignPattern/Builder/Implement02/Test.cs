using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Builder.Implement02
{
    public class Test
    {
        public void TestBuilder()
        {
            Director director = new Director();

            IProductBuilder builder = new ProductABuilder();
            Product product = director.Build(builder);
            Console.Out.WriteLine(product.ToString());

            builder = new ProductBBuilder();
            product = director.Build(builder);
            Console.Out.WriteLine(product.ToString());
        }
    }
}
