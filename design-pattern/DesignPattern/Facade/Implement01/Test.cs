using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Facade.Implement01
{
    public class Test
    {
        public void TestFacade()
        {
            Computer computer = new Computer();
            computer.Startup();

            Console.Out.WriteLine();
            computer.Shutdown();
        }
    }
}
