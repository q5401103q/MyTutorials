using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Flyweight.Implement01
{
    public class CharactorA : Charactor
    {
        public CharactorA()
        {
            this._symbol = 'A';
            this._width = 120;
            this._height = 100;
            this._ascent = 70;
            this._descent = 0;
        }

        public override void SetPointSize(int size)
        {
            this._pointsize = size;
        }

        public override void Display()
        {
            Console.Out.WriteLine(this._symbol);
        }
    }
}
