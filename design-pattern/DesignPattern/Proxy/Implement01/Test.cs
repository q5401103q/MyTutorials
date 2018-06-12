using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Proxy.Implement01
{
    public class Test
    {
        public void TestProxy()
        {
            ISource source = new Proxy();
            source.Method();
        }
    }
}
