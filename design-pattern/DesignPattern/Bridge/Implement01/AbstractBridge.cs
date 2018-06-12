using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Bridge.Implement01
{
    public abstract class AbstractBridge
    {
        private ISource _source;

        public void Method()
        {
            _source.Method();
        }

        public ISource Source
        {
            get
            {
                return _source;
            }
            set
            {
                this._source = value;
            }
        }
    }
}
