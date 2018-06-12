using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Strategy.Implement01
{
    public class Plus : AbstractCalculator, ICalculator
    {
        public double Calculate(double x, double y)
        {
            return x + y;
        }
    }
}
