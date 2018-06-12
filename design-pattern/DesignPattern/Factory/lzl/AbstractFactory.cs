using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory.lzl
{
    public abstract class AbstractFactory<T>
    {
        public abstract T GetParam();
    }
}
