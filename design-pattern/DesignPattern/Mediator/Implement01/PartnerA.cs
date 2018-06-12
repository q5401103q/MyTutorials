using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Mediator.Implement01
{
    public class PartnerA : AbstractPartner
    {
        public override void ChangeMoney(int money, AbstractMediator mediator)
        {
            mediator.AWin(money);
        }
    }
}
