using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Decorator.Implement01
{
    /// <summary>
    /// 装饰模式就是给一个对象增加一些新的功能，而且是动态的，
    /// 要求装饰对象和被装饰对象实现同一个接口，装饰对象持有被装饰对象的实例
    /// 
    /// Source类是被装饰类，Decorator类是一个装饰类，可以为Source类动态的添加一些功能
    /// </summary>
    public class Decorator : ISource
    {
        private ISource _source;

        public Decorator(ISource source) : base()
        {
            this._source = source;
        }

        public void Method()
        {
            Console.Out.WriteLine("begin process");
            _source.Method();
            Console.Out.WriteLine("end process");
        }
    }
}
