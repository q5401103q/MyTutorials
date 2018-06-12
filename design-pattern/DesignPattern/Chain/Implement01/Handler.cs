using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Chain.Implement01
{
    public abstract class Handler
    {
        protected Handler successor;

        public Handler Successor
        {
            set { this.successor = value; }
        }

        public abstract void HandleRequest(int request);
    }
}
