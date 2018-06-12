using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Memento.Implement01
{
    public class Original
    {
        private string _state;

        public string State
        {
            get { return _state; }
            set 
            { 
                _state = value;
                Console.Out.WriteLine("State changed to {0}", _state);
            }
        }

        public Memento CreateMemento()
        {
            return new Memento(_state);
        }

        public void SetMemento(Memento memento)
        {
            Console.Out.WriteLine("Storing state...");
            State = memento.State;
        }
    }
}
