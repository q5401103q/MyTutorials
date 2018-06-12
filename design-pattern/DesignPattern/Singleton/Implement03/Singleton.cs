using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Singleton.Implement03
{
    /// <summary>
    /// 线程安全的单例模式
    /// 相对于Implements02的单例模式，改进之处：
    /// 在于线程不是每次都加锁，只有判断对象实例没有被建造时它才加锁
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object _locker = new object();

        Singleton()
        { 
        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
