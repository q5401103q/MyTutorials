using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Command.Implement01
{
    public interface IGraphCommand
    {
        void Draw();
        void Undo();
    }
}
