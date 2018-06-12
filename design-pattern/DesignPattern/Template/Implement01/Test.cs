using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Template.Implement01
{
    public class Test
    {
        public void TestTemplate()
        {
            AbstractCalculator calculator = new Plus();
            double result = calculator.ToCalculate("3", "5");
            Console.Out.WriteLine(result);

            calculator = new Minus();
            result = calculator.ToCalculate("3", "5");
            Console.Out.WriteLine(result);

            calculator = new Multiply();
            result = calculator.ToCalculate("3", "5");
            Console.Out.WriteLine(result);

            calculator = new Devide();
            try
            {
                result = calculator.ToCalculate("3", "5");
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
