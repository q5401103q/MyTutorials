using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Vistor.Implement01
{
    public class MySubject : Subject
    {
        public override void Accept(IVistor vistor)
        {
            vistor.Visit(this);
        }

        public override string Print()
        {
            return this.GetType().Name;
        }
    }
}
