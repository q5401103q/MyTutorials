using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Facade.Implement01
{
    public class Cpu
    {
        public void Startup()
        {
            Console.Out.WriteLine("Cpu starts up.");
        }

        public void Shutdown()
        {
            Console.Out.WriteLine("Cpu shuts down.");
        }
    }
}
