using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement03
{
    class Test
    {
        public void TestIterator()
        {
            Person person = new Person("Zhangsan", "Lisi", "Erna");
            foreach (string s in person._names)
            {
                Console.Out.WriteLine(s);
            }
        }
    }
}
