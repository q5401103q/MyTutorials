using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Facade.Implement01
{
    public class Computer
    {
        private Cpu cpu = null;
        private Disk disk = null;
        private Memory memory = null;

        public Computer()
        {
            cpu = new Cpu();
            disk = new Disk();
            memory = new Memory();
        }

        public void Startup()
        {
            Console.Out.WriteLine("Computer is starting up...");
            cpu.Startup();
            disk.Startup();
            memory.Startup();
            Console.Out.WriteLine("Computer started.");
        }

        public void Shutdown()
        {
            Console.Out.WriteLine("Computer is shutting down...");
            cpu.Startup();
            disk.Startup();
            memory.Startup();
            Console.Out.WriteLine("Computer shutted.");
        }
    }
}
