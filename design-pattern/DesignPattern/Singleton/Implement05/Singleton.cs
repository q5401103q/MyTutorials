using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Singleton.Implement05
{
    /// <summary>
    /// 较推荐的单例模式，使用内部类持有Singleton的实例，实现了延迟初始化
    /// </summary>
    public sealed class Singleton
    {
        Singleton()
        { 
        }

        public static Singleton Instance
        {
            get
            {
                return Nested._instance;
            }
        }

        private class Nested
        {
            internal static readonly Singleton _instance = new Singleton();

            static Nested()
            { 
            }
        }
    }
}
