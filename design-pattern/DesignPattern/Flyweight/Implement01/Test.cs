using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Flyweight.Implement01
{
    public class Test
    {
        public void TestFlyweight()
        {
            CharactorA ca = CharactorFactory.Instance.GetCharactor("A") as CharactorA;
            ca.SetPointSize(11);
            ca.Display();

            CharactorB cb = CharactorFactory.Instance.GetCharactor("B") as CharactorB;
            cb.SetPointSize(12);
            cb.Display();

            CharactorC cc = CharactorFactory.Instance.GetCharactor("C") as CharactorC;
            cc.SetPointSize(13);
            cc.Display();
        }
    }
}
