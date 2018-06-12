using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Adapter.Implement02
{
    public class Test
    {
        public void TestAdapter()
        {
            Source source = new Source();
            ITarget target = new Wrapper(source);
            target.Method1();
            target.Method2();
        }
    }
}
