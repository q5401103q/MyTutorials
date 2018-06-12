using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.State.Implement01
{
    public class Test
    {
        public void TestState()
        {
            Light light = new Light();
            light.PressSwitch();
            light.PressSwitch();
            light.PressSwitch();
            light.PressSwitch();
        }
    }
}
