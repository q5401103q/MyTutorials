using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Interpreter.Implement01
{
    public class Minus : Expression
    {
        public int interpret(Context context)
        {
            return context.Num1 - context.Num2;
        }
    }
}
