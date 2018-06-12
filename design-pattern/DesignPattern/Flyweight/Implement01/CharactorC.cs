using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Flyweight.Implement01
{
    class CharactorC : Charactor
    {
        public CharactorC()
        {
            this._symbol = 'C';
            this._width = 160;
            this._height = 100;
            this._ascent = 74;
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
