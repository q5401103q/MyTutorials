using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Adapter.Implement01
{
    public class Test
    {
        public void TestAdapter()
        {
            ITarget target = new Wrapper();
            target.Method1();
            target.Method2();
        }
    }
}
