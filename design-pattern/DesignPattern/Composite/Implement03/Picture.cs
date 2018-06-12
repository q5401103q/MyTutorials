using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Composite.Implement03
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
            Console.WriteLine("Draw a " + _name.ToString());

            foreach (Graphics graphic in _childrens)
            {
                graphic.Draw();
            }
        }

        public void Add(Graphics graphic)
        {
            _childrens.Add(graphic);
        }

        public void Remove(Graphics graphic)
        {
            _childrens.Remove(graphic);
        }
    }
}
