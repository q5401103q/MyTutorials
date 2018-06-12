using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Interpreter.Implement01
{
    public class Test
    {
        public void TestInterpreter()
        {
            int result = new Minus().interpret((new Context(new Plus().interpret(new Context(9, 2)), 8)));
            Console.Out.WriteLine(result);
        }
    }
}
