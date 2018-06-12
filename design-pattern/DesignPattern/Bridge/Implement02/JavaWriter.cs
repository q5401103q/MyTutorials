using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Bridge.Implement02
{
    public class JavaWriter : Writer
    {
        public override void Write(string msg)
        {
            Console.Out.WriteLine("JavaWriter write log :{0}", msg);
        }
    }
}
