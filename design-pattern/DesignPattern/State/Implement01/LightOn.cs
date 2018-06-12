﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.State.Implement01
{
    public class LightOn : ILight
    {
        public void PressSwitch(Light light)
        {
            Console.Out.WriteLine("Light Off");
            light.State = new LightOff();
        }
    }
}
