using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Flyweight.Implement01
{
    public sealed class CharactorFactory
    {
        private Hashtable _charactors = new Hashtable();
        private static CharactorFactory _instance;

        private CharactorFactory()
        {
            _charactors.Add("A", new CharactorA());
            _charactors.Add("B", new CharactorB());
            _charactors.Add("C", new CharactorC());
        }

        public static CharactorFactory Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new CharactorFactory();
                }
                return _instance;
            }
        }

        public Charactor GetCharactor(string key)
        {
            Charactor charactor = _charactors[key] as Charactor;
            if (charactor == null)
            {
                switch (key)
                {
                    case "A": 
                        charactor = new CharactorA(); 
                        break;
                    case "B": 
                        charactor = new CharactorB(); 
                        break;
                    case "C": 
                        charactor = new CharactorC(); 
                        break;
                    default:
                        break;
                }
                _charactors.Add(key, charactor);
            }
            return charactor;
        }
    }
}
