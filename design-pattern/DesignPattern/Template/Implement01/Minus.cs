using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Template.Implement01
{
    public class Minus : AbstractCalculator
    {
        public override double Calculate(double x, double y)
        {
            return x - y;
        }
    }
}
