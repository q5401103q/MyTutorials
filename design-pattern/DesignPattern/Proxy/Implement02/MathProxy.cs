using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Proxy.Implement02
{
    public class MathProxy : IMath
    {
        private Math math = new Math();

        public double Add(double x, double y)
        {
            return math.Add(x, y);
        }

        public double Sub(double x, double y)
        {
            return math.Sub(x, y);
        }

        public double Mul(double x, double y)
        {
            return math.Mul(x, y);
        }

        public double Dev(double x, double y)
        {
            return math.Dev(x, y);
        }
    }
}
