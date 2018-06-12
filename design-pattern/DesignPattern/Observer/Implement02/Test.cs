using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Observer.Implement02
{
    public class Test
    {
        public void TestObserver()
        {
            Stock stock = new Microsoft("Microsoft", 120);
            stock.Add(new Observer("Observer1"));
            stock.Add(new Observer("Observer2"));

            stock.Update(140);
        }
    }
}
