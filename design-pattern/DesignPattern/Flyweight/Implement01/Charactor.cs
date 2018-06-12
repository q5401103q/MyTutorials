using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Flyweight.Implement01
{
    public abstract class Charactor
    {
        protected char _symbol;
        protected int _width;
        protected int _height;
        protected int _ascent;
        protected int _descent;
        protected int _pointsize;

        public abstract void SetPointSize(int size);
        public abstract void Display();
    }
}
