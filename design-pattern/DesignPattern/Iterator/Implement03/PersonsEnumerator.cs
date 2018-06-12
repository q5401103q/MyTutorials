using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Iterator.Implement03
{
    public class PersonsEnumerator : IEumerator
    {
        private int index = -1;
        private Person person;

        public PersonsEnumerator(Person person)
        {
            this.person = person;
        }

        public object Current
        {
            get { return person._names[index]; }
        }

        public bool HasNext()
        {
            index++;
            return index < person._names.Length;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
