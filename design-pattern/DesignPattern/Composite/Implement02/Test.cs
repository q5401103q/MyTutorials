using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Composite.Implement02
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

            Circle c = new Circle("test");
            try
            {
                c.Add(new Rectangle("error"));
            }
            catch (NotImplementedException ex)
            {
                Console.Out.WriteLine("An error has been thrown.");
                Console.Out.WriteLine(ex.Message);
            }

            root.Draw();
        }
    }
}
