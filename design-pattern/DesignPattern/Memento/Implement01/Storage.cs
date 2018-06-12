using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Memento.Implement01
{
    public class Storage
    {
        private Memento memento;

        public Memento Memento
        {
            get { return memento; }
            set { memento = value; }
        }
    }
}
