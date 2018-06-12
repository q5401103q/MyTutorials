using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.State.Implement01
{
    public class Light
    {
        private ILight _state;

        public Light()
        {
            _state = new LightOff();
        }

        public ILight State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void PressSwitch()
        {
            _state.PressSwitch(this);
        }
    }
}
