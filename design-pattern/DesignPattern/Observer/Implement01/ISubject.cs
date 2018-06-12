using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Observer.Implement01
{
    public interface ISubject
    {
        void Add(IObserver observer);
        void Remove(IObserver observer);
        void NotifyObservers();

        void Method();
    }
}
