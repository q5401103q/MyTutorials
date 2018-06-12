using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Vistor.Implement01
{
    public abstract class Subject
    {
        public abstract void Accept(IVistor vistor);
        public abstract string Print();
    }
}
