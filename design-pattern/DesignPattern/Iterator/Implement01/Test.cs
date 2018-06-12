using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement01
{
    public class Test
    {
        public void TestIterator()
        {
            Collection collection = new MyCollection();
            Iterator it = collection.Iterator();

            while (it.HasNext())
            {
                Console.Out.WriteLine(it.Next());
            }
        }
    }
}
