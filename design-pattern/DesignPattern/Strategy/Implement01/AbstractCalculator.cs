using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Strategy.Implement01
{
    public abstract class AbstractCalculator
    {
        public bool Check(double x, double y)
        {
            if (y == 0)
                return false;
            return true;
        }
    }
}
