using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Prototype.lzl
{
    [Serializable]
    abstract class AbstractPrototype
    {
        public Member Member { get; set; }

        public abstract AbstractPrototype Clone(bool isDeep);
    }
}
