using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement02
{
    public class Test
    {
        public void TestIterator()
        {
            IIterator<string> iterator;

            IList<string> list = new List<string>();
            list.Add("zhangsan");
            list.Add("lisi");
            list.Add("erna");
            iterator = list.GetIterator();

            while (iterator.HasNext())
            {
                Console.Out.WriteLine(iterator.CurrentItem());
                iterator.Next();
            }
        }
    }
}
