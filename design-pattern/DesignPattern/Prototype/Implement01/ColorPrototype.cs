using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Prototype.Implement01
{
    [Serializable]
    public abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone(bool deep);
    }
}
