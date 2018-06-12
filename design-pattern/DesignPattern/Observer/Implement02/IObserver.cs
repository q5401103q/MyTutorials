using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Observer.Implement02
{
    public interface IObserver
    {
        void SendData(Stock stock);
    }
}
