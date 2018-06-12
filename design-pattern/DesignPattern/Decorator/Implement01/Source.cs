using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Decorator.Implement01
{
    public class Source : ISource
    {
        public void Method()
        {
            Console.Out.WriteLine("Source.Method");
        }
    }
}
