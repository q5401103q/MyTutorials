using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Bridge.Implement01
{
    public class Test
    {
        public void TestBridge()
        {
            AbstractBridge bridge = new Bridge();

            ISource sourceA = new SourceA();
            bridge.Source = sourceA;
            bridge.Method();

            ISource sourceB = new SourceB();
            bridge.Source = sourceB;
            bridge.Method();
        }
    }
}
