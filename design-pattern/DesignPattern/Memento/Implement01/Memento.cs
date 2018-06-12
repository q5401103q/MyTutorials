using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Memento.Implement01
{
    public class Memento
    {
        private string _state;

        public Memento(string state)
        {
            this._state = state;
        }

        public string State
        {
            get { return _state; }
        }
    }
}
