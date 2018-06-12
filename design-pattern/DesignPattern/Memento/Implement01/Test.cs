using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Memento.Implement01
{
    public class Test
    {
        public void TestMemento()
        {
            Original org = new Original();
            org.State = "on";

            Storage storage = new Storage();
            storage.Memento = org.CreateMemento();

            org.State = "off";
            org.SetMemento(storage.Memento);

        }
    }
}
