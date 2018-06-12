using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Observer.Implement01
{
    public class Test
    {
        public void TestObserver()
        {
            ISubject subject = new MySubject();
            subject.Add(new Observer1());
            subject.Add(new Observer2());

            subject.Method();
        }
    }
}
