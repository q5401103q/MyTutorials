using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement02
{
    public interface IIterator<T>
    {
        bool HasNext();
        T CurrentItem();
        void First();
        void Next();
    }
}
