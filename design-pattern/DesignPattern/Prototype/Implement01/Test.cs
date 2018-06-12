using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Prototype.Implement01
{
    public class Test
    {
        public void TestPrototype()
        {
            ColorManager manager = new ColorManager();

            manager["red"] = new ConcteteColorPrototype(255, 0, 0);
            manager["green"] = new ConcteteColorPrototype(0, 255, 0);
            manager["blue"] = new ConcteteColorPrototype(0, 0, 255);
            manager["angry"] = new ConcteteColorPrototype(255, 54, 0);
            manager["peace"] = new ConcteteColorPrototype(128, 211, 128);
            manager["flame"] = new ConcteteColorPrototype(211, 34, 20);

            string colorName = "red";
            ConcteteColorPrototype color1 = (ConcteteColorPrototype)manager[colorName].Clone(false);
            color1.Display(colorName);

            colorName = "peace";
            ConcteteColorPrototype color2 = (ConcteteColorPrototype)manager[colorName].Clone(true);
            color2.Display(colorName);

            colorName = "flame";
            ConcteteColorPrototype color3 = (ConcteteColorPrototype)manager[colorName].Clone(true);
            color3.Display(colorName);

            Console.ReadLine();
        }
    }
}
