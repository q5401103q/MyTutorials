using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement02
{
    public class MyIterator<T> : IIterator<T>
    {
        private List<T> _list;
        private int _index;

        public MyIterator(List<T> list)
        {
            this._list = list;
            _index = 0;
        }

        public bool HasNext()
        {
            if (_index < _list.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T CurrentItem()
        {
            return (T)_list.GetElement(_index);
        }

        public void First()
        {
            _index = 0;
        }

        public void Next()
        {
            if (_index < _list.Length)
            {
                _index++;
            }
        }
    }
}
