using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Proxy.Implement02
{
    public class Math : IMath
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Dev(double x, double y)
        {
            if (y == 0)
                throw new ArgumentException("被除数不能为0");
            return x / y;
        }
    }
}
