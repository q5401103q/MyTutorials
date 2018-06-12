using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Observer.Implement04
{
    public class Stock
    {
        public delegate void NotifyEventHandler(object sender);
        public NotifyEventHandler NotifyEvent;
        private string _name;
        private double _price;

        public string Name
        {
            get { return _name; }
        }

        public double Price
        {
            get { return _price; }
        }

        public Stock(string name, double price)
        {
            this._name = name;
            this._price = price;
        }

        public void Update(double price)
        {
            this._price = price;
            if (NotifyEvent != null)
            {
                NotifyEvent(this);
            }
        }
    }
}
