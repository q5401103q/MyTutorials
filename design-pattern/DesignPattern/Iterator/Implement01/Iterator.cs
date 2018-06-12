using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement01
{
    public interface Iterator
    {
        object Previous();
        object Next();
        bool HasNext();
        object First();
    }
}
