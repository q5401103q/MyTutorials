using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Mediator.Implement01
{
    public abstract class AbstractPartner
    {
        public int Money { get; set; }

        public AbstractPartner()
        {
            Money = 0;
        }

        public abstract void ChangeMoney(int money, AbstractMediator mediator);
    }
}
