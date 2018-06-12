using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement02
{
    public interface IList<T>
    {
        IIterator<T> GetIterator();
        void Add(T t);
    }
}
