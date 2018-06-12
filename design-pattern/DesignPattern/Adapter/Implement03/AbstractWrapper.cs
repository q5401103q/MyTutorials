using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Adapter.Implement03
{
    public abstract class AbstractWrapper : ISource
    {
        public virtual void Method1() { }
        public virtual void Method2() { }
        public virtual void Method3() { }
    }
}
