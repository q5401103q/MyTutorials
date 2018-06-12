using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Observer.Implement01
{
    public class MySubject : AbstractSubject
    {
        public override void Method()
        {
            Console.Out.WriteLine("self update...");
            NotifyObservers();
        }
    }
}
