using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Factory.Implement02
{
    public class Test
    {
        public void TestFactory()
        {
            RealFactory factory = new RealFactory();
            AbstractProduct product = factory.MakeProduct(typeof(ChineseProduct));
            product.Show();

            product = factory.MakeProduct(typeof(KoreanProduct));
            product.Show();
        }
    }
}
