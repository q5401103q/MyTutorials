using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Composite.Implement02
{
    public class Circle : Graphics
    {
        public Circle(string name)
            : base(name)
        {

        }

        public override void Draw()
        {
            Console.Out.WriteLine("Draw a " + _name.ToString());
        }

        public override void Add(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
