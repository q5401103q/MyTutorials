using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Bridge.Implement01
{
    public class SourceB : ISource
    {
        public void Method()
        {
            Console.Out.WriteLine("SourceB.Method");
        }
    }
}
