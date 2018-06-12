using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Proxy.Implement01
{
    public class Proxy : ISource
    {
        private Source _source;

        public Proxy()
        {
            this._source = new Source();
        }

        public void Method()
        {
            PreProcess();
            _source.Method();
            PostProcess();
        }

        private void PreProcess()
        {
            Console.Out.WriteLine("Proxy.PreProcess");
        }

        private void PostProcess()
        {
            Console.Out.WriteLine("Proxy.PostProcess");
        }
    }
}
