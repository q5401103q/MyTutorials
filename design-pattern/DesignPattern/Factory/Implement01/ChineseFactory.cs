using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Factory.Implement01
{
    public class ChineseFactory : AbstractFactory
    {
        public override AbstractProduct MakeProduct()
        {
            return new ChineseProduct();
        }
    }
}
