using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Bridge.Implement02
{
    public class CSharpWriter : Writer
    {
        public override void Write(string msg)
        {
            Console.Out.WriteLine("CSharpWriter write log :{0}", msg);
        }
    }
}
