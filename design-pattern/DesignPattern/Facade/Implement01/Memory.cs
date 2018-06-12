using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Facade.Implement01
{
    public class Memory
    {
        public void Startup()
        {
            Console.Out.WriteLine("Memory starts up.");
        }

        public void Shutdown()
        {
            Console.Out.WriteLine("Memory shuts down.");
        }
    }
}
