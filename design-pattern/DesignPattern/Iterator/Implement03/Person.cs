using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement03
{
    public class Person : IEnumerable
    {
        public string[] _names;

        public Person(params string[] name)
        {
            _names = new string[name.Length];
            name.CopyTo(_names, 0);
        }

        private string this[int index]
        {
            get { return _names[index]; }
            set { _names[index] = value; }
        }

        public IEumerator GetIEumerator()
        {
            return new PersonsEnumerator(this);
        }
    }
}
