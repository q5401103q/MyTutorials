using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Chain.Implement01
{
    public class Test
    {
        public void TestChain()
        {
            int[] requests = new int[] { 12, 2, 65, -1, 33, 18, 6, 25, 13 };

            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();

            h1.Successor = h2;
            h2.Successor = h3;

            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }
        }
    }
}
