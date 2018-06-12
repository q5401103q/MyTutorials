using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Facade.Implement02
{
    public class Bank
    {
        public bool HasSavings(Customer customer)
        {
            Console.Out.WriteLine("Check {0}'s bank system.",customer.Name);
            return true;
        }
    }
}
