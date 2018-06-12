using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Proxy.Implement01
{
    public class Source : ISource
    {
        public void Method()
        {
            Console.Out.WriteLine("Source.Method");
        }
    }
}
