using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement01
{
    public interface Collection
    {
        Iterator Iterator();
        object Get(int index);
        int Count();
    }
}
