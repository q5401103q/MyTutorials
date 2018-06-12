using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Singleton.Implement01
{
    /// <summary>
    /// 单例模式的最简单的实现
    /// 非线程安全的，多线程访问可能都会建造Singleton实例
    /// 例如，两个线程同时判断 _instance == null,且都得到true的结果
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton _instance = null;

        Singleton()
        {
        }

        public static Singleton Instance
        {
            get 
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
