using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Template.Implement01
{
    public class Devide : AbstractCalculator
    {
        public override double Calculate(double x, double y)
        {
            if (Check(x, y))
                return x / y;
            throw new ArgumentException("参数非法，请仔细核对");
        }
    }
}
