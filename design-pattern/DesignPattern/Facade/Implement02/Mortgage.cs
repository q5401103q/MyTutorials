using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Facade.Implement02
{
    public class Mortgage
    {
        private Bank bank = null;
        private Loan loan = null;
        private Credit credit = null;

        public Mortgage()
        {
            bank = new Bank();
            loan = new Loan();
            credit = new Credit();
        }

        public bool Check(Customer customer)
        {
            bool checkResult = true;

            if (!bank.HasSavings(customer))
            {
                checkResult = false;
            }
            else if (!loan.HasNoLoan(customer))
            {
                checkResult = false;
            }
            else if (!credit.HasGoodCredit(customer))
            {
                checkResult = false;
            }
            return checkResult;
        }
    }
}
