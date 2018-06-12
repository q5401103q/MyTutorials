using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Command.Implement01
{
    public class Line : IGraphCommand
    {
        private string _name;

        public Line(string name)
        {
            this._name = name;
        }

        public void Draw()
        {
            Console.Out.WriteLine("Draw a line");
        }

        public void Undo()
        {
            Console.Out.WriteLine("Undo a line");
        }
    }
}
