using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Mediator.Implement01
{
    public class Mediator : AbstractMediator
    {
        public Mediator(AbstractPartner A, AbstractPartner B)
            : base(A, B)
        {
            
        }

        public override void AWin(int count)
        {
            A.Money += count;
            B.Money -= count;
        }

        public override void BWin(int count)
        {
            A.Money -= count;
            B.Money += count;
        }
    }
}
