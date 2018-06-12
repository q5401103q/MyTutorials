using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Template.Implement02
{
    public class Test
    {
        public void TestTemplate()
        {
            DataAccessObject dao = null;

            dao = new Category();
            dao.Run();

            dao = new Product();
            dao.Run();

            Console.Read();
        }
    }
}
