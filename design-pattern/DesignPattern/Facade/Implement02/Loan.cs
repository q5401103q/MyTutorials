using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Facade.Implement02
{
    public class Loan
    {
        public bool HasNoLoan(Customer customer)
        {
            Console.Out.WriteLine("Check {0}'s load system.", customer.Name);
            return true;
        }
    }
}
