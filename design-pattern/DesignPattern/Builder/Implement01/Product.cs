using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Builder.Implement01
{
    public class Product
    {
        public int _attribute1;
        public decimal _attribute2;
        public double _attribute3;
        public string _attribute4;
        public DateTime _attribute5;
        public KeyValuePair<string, float> _attribute6;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("attribute1 is {0}", _attribute1);
            sb.AppendLine();
            sb.AppendFormat("attribute2 is {0}", _attribute2);
            sb.AppendLine();
            sb.AppendFormat("attribute3 is {0}", _attribute3);
            sb.AppendLine();
            sb.AppendFormat("attribute4 is {0}", _attribute4);
            sb.AppendLine();
            sb.AppendFormat("attribute5 is {0}", _attribute5.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine();
            sb.AppendFormat("attribute6 is <{0},{1}>", _attribute6.Key, _attribute6.Value);
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
