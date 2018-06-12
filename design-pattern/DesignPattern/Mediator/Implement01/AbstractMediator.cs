using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Mediator.Implement01
{
    public abstract class AbstractMediator
    {
        protected AbstractPartner A;
        protected AbstractPartner B;

        public AbstractMediator(AbstractPartner A, AbstractPartner B)
        {
            this.A = A;
            this.B = B;
        }

        public abstract void AWin(int count);
        public abstract void BWin(int count);
    }
}
