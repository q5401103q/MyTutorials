using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Bridge.Implement02
{
    public abstract class Log
    {
        protected Writer _writer;

        public Writer Writer 
        {
            set
            {
                this._writer = value;
            }
        }

        public virtual void Write(string msg)
        {
            _writer.Write(msg);
        }
    }
}
