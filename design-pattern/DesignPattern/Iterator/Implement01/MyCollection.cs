using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement01
{
    public class MyCollection : Collection
    {
        public string[] array = {"A","B","C","D","E"}; 

        public Iterator Iterator()
        {
            return new MyIterator(this);
        }

        public object Get(int index)
        {
            return array[index];
        }

        public int Count()
        {
            return array.Length;
        }
    }
}
