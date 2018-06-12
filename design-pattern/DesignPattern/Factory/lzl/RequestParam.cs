using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory.lzl
{
    class RequestParam : AbstractParam
    {
        public override string ToString()
        {
            return string.Format("({0},{1})", this.ID, this.Name);
        }
    }
}
