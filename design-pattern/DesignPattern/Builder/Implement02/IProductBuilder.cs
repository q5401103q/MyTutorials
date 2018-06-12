using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Builder.Implement02
{
    public interface IProductBuilder
    {
        void BuildAttribute1();
        void BuildAttribute2();
        void BuildAttribute3();
        void BuildAttribute4();
        void BuildAttribute5();
        void BuildAttribute6();

        Product Build();
    }
}
