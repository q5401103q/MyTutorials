using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Vistor.Implement01
{
    public class Test
    {
        public void TestVistor()
        {
            IVistor vistor = new MyVistor();
            Subject subject = new MySubject();

            subject.Accept(vistor);
        }
    }
}
