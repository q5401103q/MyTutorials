using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Proxy.Implement02
{
    public class Test
    {
        public void TestProxy()
        {
            MathProxy proxy = new MathProxy();
            double addresult = proxy.Add(2, 3);
            double subresult = proxy.Sub(2, 3);
            double mulresult = proxy.Mul(2, 3);
            double devresult = 0;
            double expresult = 0;
            try
            {
                devresult = proxy.Dev(2, 3);
                expresult = proxy.Dev(3, 0);
            }
            catch (ArgumentException ex)
            {
                Console.Out.WriteLine(ex.Message);
            }

            Console.Out.WriteLine("{0},{1},{2},{3},{4}", addresult, subresult, mulresult, devresult, expresult);
            
        }
    }
}
