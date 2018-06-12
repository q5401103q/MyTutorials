using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Command.Implement01
{
    public class Test 
    {
        public void TestCommand()
        {
            Line line = new Line("Line A");
            Rectangle rect = new Rectangle("Rectangle A");
            Circle circle = new Circle("Circle A");

            Graphics graphics = new Graphics();
            graphics.Draw(line);
            graphics.Draw(rect);
            graphics.Undo();
            graphics.Draw(circle);
        }
    }
}
