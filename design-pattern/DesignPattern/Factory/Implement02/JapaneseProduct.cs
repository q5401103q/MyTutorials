using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Factory.Implement02
{
    public class JapaneseProduct : AbstractProduct
    {
        public override void Show()
        {
            Console.Out.WriteLine("This is Japanese product.");
        }
    }
}
