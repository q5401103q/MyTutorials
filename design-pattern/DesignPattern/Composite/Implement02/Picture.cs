using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Composite.Implement02
{
    public class Picture : Graphics
    {
        protected List<Graphics> _childrens = new List<Graphics>();

        public Picture(string name)
            : base(name)
        {

        }

        public override void Draw()
        {
            Console.Out.WriteLine("Draw a " + _name.ToString());
            foreach (Graphics graphics in _childrens)
            {
                graphics.Draw();
            }
        }

        public override void Add(Graphics graphics)
        {
            _childrens.Add(graphics);
        }

        public override void Remove(Graphics graphics)
        {
            _childrens.Remove(graphics);
        }
    }
}
