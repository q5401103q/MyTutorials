using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Command.Implement01
{
    public class Circle : IGraphCommand
    {
        private string _name;

        public Circle(string name)
        {
            this._name = name;
        }

        public void Draw()
        {
            Console.Out.WriteLine("Draw a circle");
        }

        public void Undo()
        {
            Console.Out.WriteLine("Undo a circle");
        }
    }
}
