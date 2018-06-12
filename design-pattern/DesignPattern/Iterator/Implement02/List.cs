using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement02
{
    /// <summary>
    /// 模仿c# System.Collections.Generic.List<T>
    /// 这里没有用到任何C#的特性
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class List<T> : IList<T>
    {
        private int _defaultCapacity = 0;
        T[] _list;
        T[] _temp;

        public List()
        {
            _list = new T[_defaultCapacity];
        }

        public IIterator<T> GetIterator()
        {
            return new MyIterator<T>(this);
        }

        public int Length
        {
            get { return _list.Length; }
        }

        public T GetElement(int index)
        {
            return _list[index];
        }

        public void Add(T t)
        {
            _defaultCapacity++;
            _temp = new T[_defaultCapacity];
            Array.Copy(_list, _temp, _list.Length);
            _temp[_defaultCapacity - 1] = t;

            _list = new T[_defaultCapacity];
            Array.Copy(_temp, _list, _defaultCapacity);

            _temp = null;
        }
    }
}
