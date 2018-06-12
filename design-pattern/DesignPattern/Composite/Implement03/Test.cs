using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Composite.Implement03
{
    public class Test
    {
        public void TestComposite()
        {
            Picture root = new Picture("root");

            root.Add(new Line("line1"));
            root.Add(new Line("line2"));
            root.Add(new Circle("circle"));
            root.Add(new Rectangle("Rectangle"));

            root.Draw();
        }
    }
}
