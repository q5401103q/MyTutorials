using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Adapter.Implement01
{
    /// <summary>
    /// 类的适配器
    /// 有一个Source类，拥有一个方法Method1待适配，目标接口时ITarget，
    /// 通过Wrapper类，将Source的功能扩展到ITarget里
    /// Wrapper类继承Source类，实现ITarget接口
    /// </summary>
    public class Wrapper : Source, ITarget
    {
        public void Method2()
        {
            Console.Out.WriteLine("Adapter.Method2");
        }
    }
}
