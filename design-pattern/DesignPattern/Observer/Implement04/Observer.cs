using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Observer.Implement04
{
    /// <summary>
    /// 一种更加优雅的观察者模式
    /// 
    /// 借助于C#的委托、事件实现对观察者的通知
    /// 
    /// 前面的例子虽然取消了直接耦合，但是又引入了不必要的约束，
    /// 即那些子类必须都继承于主题父类，还有观察者接口等
    /// </summary>
    public class Observer
    {
        private string _name;

        public Observer(string name)
        {
            this._name = name;
        }

        public void SendData(object sender)
        {
            if (sender is Stock)
            {
                Stock stock = sender as Stock;
                Console.Out.WriteLine("Notify {0}: {1}'s price has changed to {2:C}", _name, stock.Name, stock.Price);
            }
        }
    }
}
