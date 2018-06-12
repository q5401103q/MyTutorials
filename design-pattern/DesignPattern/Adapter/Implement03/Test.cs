using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Adapter.Implement03
{
    public class Test
    {
        public void TestAdapter()
        {
            ISource source1 = new Wrapper1();
            source1.Method1();
            source1.Method2();
            source1.Method3();

            ISource source2 = new Wrapper2();
            source2.Method1();
            source2.Method2();
            source2.Method3();
        }
    }
}
