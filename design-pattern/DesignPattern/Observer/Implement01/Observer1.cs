using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Observer.Implement01
{
    public class Observer1 : IObserver
    {
        public void update()
        {
            Console.Out.WriteLine("observer1 has received!"); 
        }
    }
}
