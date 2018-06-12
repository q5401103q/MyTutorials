using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Flyweight.Implement01
{
    public class CharactorB : Charactor
    {
        public CharactorB()
        {
            this._symbol = 'B';
            this._width = 140;
            this._height = 100;
            this._ascent = 72;
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
