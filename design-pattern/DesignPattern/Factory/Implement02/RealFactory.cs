using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Factory.Implement02
{
    public class RealFactory: IFactory<AbstractProduct>
    {
        public AbstractProduct MakeProduct(Type t)
        {
            return (AbstractProduct)Activator.CreateInstance(t);
        }
    }
}
