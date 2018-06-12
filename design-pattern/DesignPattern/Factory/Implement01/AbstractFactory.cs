using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Factory.Implement01
{
    public abstract class AbstractFactory
    {
        public abstract AbstractProduct MakeProduct();
    }
}
