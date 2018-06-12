using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Bridge.Implement02
{
    public class JavaLog : Log
    {
        public override void Write(string msg)
        {
            _writer.Write(msg);
        }
    }
}
