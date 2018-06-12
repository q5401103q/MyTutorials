using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Builder.Implement02
{
    public class Director
    {
        public Product Build(IProductBuilder builder)
        {
            builder.BuildAttribute1();
            builder.BuildAttribute2();
            builder.BuildAttribute3();
            builder.BuildAttribute4();
            builder.BuildAttribute5();
            builder.BuildAttribute6();

            return builder.Build();
        }
    }
}
