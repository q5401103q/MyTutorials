using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement01
{
    public class MyIterator : Iterator
    {
        private Collection _collection;
        private int _index = -1;

        public MyIterator(Collection collection)
        {
            this._collection = collection;
        }

        public object Previous()
        {
            if (_index > 0)
            {
                _index--;
            }
            return _collection.Get(_index);
        }

        public object Next()
        {
            if (_index < _collection.Count() - 1)
            {
                _index++;
            }
            return _collection.Get(_index);
        }

        public bool HasNext()
        {
            if (_index < _collection.Count() - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object First()
        {
            _index = 0;
            return _collection.Get(_index);
        }
    }
}
