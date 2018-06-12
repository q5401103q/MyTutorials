using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Vistor.Implement01
{
    public interface IVistor
    {
        void Visit(Subject subject);
    }
}
