using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Mediator.Implement01
{
    public class Test
    {
        public void TestMediator()
        {
            AbstractPartner a = new PartnerA();
            AbstractPartner b = new PartnerB();

            a.Money = 20;
            b.Money = 20;

            AbstractMediator mediator = new Mediator(a, b);

            a.ChangeMoney(5, mediator);
            Console.Out.WriteLine("A目前的钱是{0}", a.Money);
            Console.Out.WriteLine("B目前的钱是{0}", b.Money);

            b.ChangeMoney(10, mediator);
            Console.Out.WriteLine("A目前的钱是{0}", a.Money);
            Console.Out.WriteLine("B目前的钱是{0}", b.Money);
        }
    }
}
