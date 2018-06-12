using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Strategy.Implement01
{
    public class Test
    {
        public void TestStrategy()
        {
            ICalculator calculator = null;
            double result = 0;

            calculator = new Plus();
            result = calculator.Calculate(2, 3);
            Console.Out.WriteLine(result);

            calculator = new Minus();
            result = calculator.Calculate(2, 3);
            Console.Out.WriteLine(result);

            calculator = new Multiply();
            result = calculator.Calculate(2, 3);
            Console.Out.WriteLine(result);

            calculator = new Devide();
            try
            {
                result = calculator.Calculate(2, 3);
            }
            catch (ArgumentException ex)
            {
                result = 0;
                Console.Out.WriteLine(ex.Message);
            }
            Console.Out.WriteLine(result);
        }
    }
}
