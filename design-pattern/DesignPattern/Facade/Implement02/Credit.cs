using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Facade.Implement02
{
    public class Credit
    {
        public bool HasGoodCredit(Customer customer)
        {
            Console.Out.WriteLine("Check {0}'s credit system.",customer.Name);
            return true;
        }
    }
}
