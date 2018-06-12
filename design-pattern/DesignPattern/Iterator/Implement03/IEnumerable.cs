using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement03
{
    public interface IEnumerable
    {
        IEumerator GetIEumerator();
    }
}
