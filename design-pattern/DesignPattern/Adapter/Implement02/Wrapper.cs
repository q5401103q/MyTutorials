using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Adapter.Implement02
{
    /// <summary>
    /// 对象的适配器
    /// 基本思路和类的适配器模式相同，只是将Wrapper类作修改
    /// 这次不继承Source类，而是持有Source类的实例，以达到解决兼容性的问题。
    /// </summary>
    public class Wrapper : ITarget
    {
        private Source _source;

        public Wrapper(Source source) : base()
        {
            this._source = source;
        }

        public void Method1()
        {
            _source.Method1();
        }

        public void Method2()
        {
            Console.Out.WriteLine("Adapter.Method2");
        }
    }
}
