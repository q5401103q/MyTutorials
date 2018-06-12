using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Vistor.Implement01
{
    public class YourVistor : IVistor
    {
        public void Visit(Subject subject)
        {
            Console.Out.WriteLine("visit subject:{0}", subject.Print());
        }
    }
}
