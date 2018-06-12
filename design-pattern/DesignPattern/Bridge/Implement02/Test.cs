using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Bridge.Implement02
{
    public class Test
    {
        public void TestBridge()
        {
            Writer jWriter = new JavaWriter();
            Log jLog = new JavaLog();
            jLog.Writer = jWriter;
            jLog.Write("Hello");

            Writer cWriter = new CSharpWriter();
            Log cLog = new CSharpLog();
            cLog.Writer = cWriter;
            cLog.Write("World");
        }
    }
}
