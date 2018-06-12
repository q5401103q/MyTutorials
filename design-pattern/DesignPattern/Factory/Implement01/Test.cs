using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Factory.Implement01
{
    public class Test
    {
        public void TestFactory()
        {
            AbstractFactory factory = new ChineseFactory();
            AbstractProduct product = factory.MakeProduct();
            product.Show();

            factory = new JapaneseFactory();
            product = factory.MakeProduct();
            product.Show();
        }
    }
}
