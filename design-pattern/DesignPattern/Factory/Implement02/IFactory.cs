using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Factory.Implement02
{
    interface IFactory<T> where T : AbstractProduct
    {
        T MakeProduct(Type t);
    }
}
