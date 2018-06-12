using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Observer.Implement03
{
    /// <summary>
    /// 拉模式
    /// 
    /// 当有消息时，通知消息的方法本身并不带任何的参数，
    /// 是由观察者自己到主体对象那儿取回（拉）消息
    /// 
    /// 当然拉模式也是有一些缺点的，主体对象和观察者之间的耦合加强了，
    /// 但是这可以通过抽象的手段使这种耦合关系减到最小
    /// </summary>
    public class Observer : IObserver
    {
        private string _name;
        private Stock _stock;

        public Observer(string name, Stock stock)
        {
            this._name = name;
            this._stock = stock;
        }

        public void SendData()
        {
            Console.Out.WriteLine("Notify {0}: {1}'s price has changed to {2:C}", _name, _stock.Name, _stock.Price);
        }
    }
}
