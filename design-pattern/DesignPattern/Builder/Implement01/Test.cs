using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Builder.Implement01
{
    public class Test
    {
        public void TestBuilder()
        {
            Product product = new ProductBuilder()
                                .Attribute1(3)
                                .Attribute2((decimal)4)
                                .Attribute3(5d)
                                .Attribute4("TEST")
                                .Attribute5(DateTime.Now)
                                .Attribute6(new KeyValuePair<string, float>("pair", 6f))
                                .Build();

            Console.Out.WriteLine(product.ToString());
        }
    }
}
