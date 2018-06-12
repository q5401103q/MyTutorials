using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Interpreter.Implement01
{
    public interface Expression
    {
        int interpret(Context context);
    }
}
