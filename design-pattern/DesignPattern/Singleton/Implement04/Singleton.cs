using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Singleton.Implement04
{
    /// <summary>
    /// 线程安全
    /// 公共语言运行库负责处理变量初始化
    /// 缺点是无法控制实例化
    /// </summary>
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        static Singleton()
        { 
        }

        Singleton()
        { 
        }

        public static Singleton Instance
        {
            get { return _instance; }
        }
    }
}
