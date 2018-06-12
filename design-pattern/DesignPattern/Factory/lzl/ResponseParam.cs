using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory.lzl
{
    class ResponseParam : AbstractParam
    {
        public override string ToString()
        {
            return string.Format("({0},{1},{2})", this.ID, this.Name);
        }
    }
}
