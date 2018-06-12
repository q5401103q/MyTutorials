using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Observer.Implement02
{
    /// <summary>
    /// 推模式
    /// 
    /// 当有消息时，所有的观察者都会直接得到全部的消息，并进行相应的处理程序，
    /// 与主体对象没什么关系，两者之间的关系是一种松散耦合
    /// 
    /// 它也有缺陷，
    /// 第一是所有的观察者得到的消息是一样的，
    /// 也许有些信息对某个观察者来说根本就用不上，也就是观察者不能“按需所取”；
    /// 第二，当通知消息的参数有变化时，所有的观察者对象都要变化
    /// </summary>
    public class Observer : IObserver
    {
        private string _name;

        public Observer(string name)
        {
            this._name = name;
        }

        public void SendData(Stock stock)
        {
            Console.Out.WriteLine("Notify {0}: {1}'s price has changed to {2:C}", _name, stock.Name, stock.Price);
        }
    }
}
