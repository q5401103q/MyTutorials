using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Facade.Implement01
{
    public class Disk
    {
        public void Startup()
        {
            Console.Out.WriteLine("Disk starts up.");
        }

        public void Shutdown()
        {
            Console.Out.WriteLine("Disk shuts down.");
        }
    }
}
