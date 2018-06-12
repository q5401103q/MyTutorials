using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Template.Implement01
{
    public abstract class AbstractCalculator
    {
        public double ToCalculate(string x, string y)
        {
            return Calculate(Convert(x), Convert(y));
        }

        public bool Check(double x, double y)
        {
            if (y == 0)
                return false;
            return true;
        }

        public double Convert(string value)
        {
            double result = 0;
            double.TryParse(value, out result);
            return result;
        }

        public abstract double Calculate(double x, double y);
    }
}
