using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Composite.Implement03
{
    public class Line : Graphics
    {
        public Line(string name)
            : base(name)
        {

        }

        public override void Draw()
        {
            Console.WriteLine("Draw a " + _name.ToString());
        }
    }
}
