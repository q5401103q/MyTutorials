using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Proxy.Implement02
{
    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Dev(double x, double y);
    }
}
