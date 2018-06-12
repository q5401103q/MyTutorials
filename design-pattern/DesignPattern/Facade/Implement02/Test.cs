using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Facade.Implement02
{
    public class Test
    {
        public void TestFacade()
        {
            Mortgage mortgage = new Mortgage();
            Customer customer = new Customer("Liuzl");

            bool checkResult = mortgage.Check(customer);

            Console.WriteLine(checkResult);
            Console.ReadLine();
        }
    }
}
