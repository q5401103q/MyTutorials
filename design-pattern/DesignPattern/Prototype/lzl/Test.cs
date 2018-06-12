using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Prototype.lzl
{
    class Test
    {
        public static void Main(string[] args)
        {
            AbstractPrototype orginalTarget = new MyPrototype();
            orginalTarget.Member = new Member() { Name = "00", Value = "orginalTarget" };
            AbstractPrototype shallowTarget = orginalTarget.Clone(false);
            AbstractPrototype deepTarget = orginalTarget.Clone(true);

            Console.WriteLine(orginalTarget.ToString());
            Console.WriteLine(shallowTarget.ToString());
            Console.WriteLine(deepTarget.ToString());

            Console.WriteLine("===============Change Name==============");
            orginalTarget.Member.Value = "changedTarget";
            Console.WriteLine(orginalTarget.ToString());
            Console.WriteLine(shallowTarget.ToString());
            Console.WriteLine(deepTarget.ToString());

            Console.WriteLine("===============Change Name==============");
            shallowTarget.Member.Value = "shallowTarget";
            Console.WriteLine(orginalTarget.ToString());
            Console.WriteLine(shallowTarget.ToString());
            Console.WriteLine(deepTarget.ToString());
            
            Console.WriteLine("===============Change Name==============");
            deepTarget.Member.Value = "deepTarget";
            Console.WriteLine(orginalTarget.ToString());
            Console.WriteLine(shallowTarget.ToString());
            Console.WriteLine(deepTarget.ToString());

            Console.Read();
        }
    }
}
