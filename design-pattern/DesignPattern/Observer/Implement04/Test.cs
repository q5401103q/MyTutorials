using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Observer.Implement04
{
    public class Test
    {
        public void TestObserver()
        {
            Stock stock = new Stock("Microsoft", 120);
            Observer observer1 = new Observer("Observer1");
            Observer observer2 = new Observer("Observer2");

            stock.NotifyEvent += new Stock.NotifyEventHandler(observer1.SendData);
            stock.NotifyEvent += new Stock.NotifyEventHandler(observer2.SendData);

            stock.Update(140);
        }
    }
}
