using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Decorator.Implement01
{
    public class Test
    {
        public void TestDecorator()
        {
            ISource source = new Source();
            ISource decorator = new Decorator(source);
            decorator.Method();
        }
    }
}
