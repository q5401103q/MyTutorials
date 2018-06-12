using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Chain.Implement01
{
    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request < 10)
            {
                Console.Out.WriteLine("{0} handles request {1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}
