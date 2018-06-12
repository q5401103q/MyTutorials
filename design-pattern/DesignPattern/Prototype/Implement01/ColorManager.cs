using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Prototype.Implement01
{
    public class ColorManager
    {
        Hashtable colors = new Hashtable();

        public ColorPrototype this[string name]
        {
            get 
            {
                return (ColorPrototype)colors[name];
            }
            set
            {
                colors.Add(name, value);
            }
        }
    }
}
