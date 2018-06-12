using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Factory.Implement01
{
    public class JapaneseFactory : AbstractFactory
    {
        public override AbstractProduct MakeProduct()
        {
            return new JapaneseProduct();
        }
    }
}
