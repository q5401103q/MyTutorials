using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Command.Implement01
{
    public class Rectangle : IGraphCommand
    {
        private string _name;

        public Rectangle(string name)
        {
            this._name = name;
        }

        public void Draw()
        {
            Console.Out.WriteLine("Draw a rectangle");
        }

        public void Undo()
        {
            Console.Out.WriteLine("Undo a rectangle");
        }
    }
}
