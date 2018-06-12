using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Command.Implement01
{
    public class Graphics
    {
        Stack<IGraphCommand> commands = new Stack<IGraphCommand>();

        public void Draw(IGraphCommand command)
        {
            command.Draw();
            commands.Push(command);
        }

        public void Undo()
        {
            IGraphCommand command = commands.Pop();
            command.Undo();
        }
    }
}
