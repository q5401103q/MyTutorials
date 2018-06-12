using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Singleton.Implement02
{
    /// <summary>
    /// 线程安全的Singleton
    /// 缺点是增加了额外开销，即locker，损失性能
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
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }
        }
    }
}
