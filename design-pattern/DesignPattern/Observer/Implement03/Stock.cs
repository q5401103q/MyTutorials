using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Observer.Implement03
{
    public abstract class Stock
    {
        private List<IObserver> observers = new List<IObserver>();

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

            foreach (IObserver observer in observers)
            {
                observer.SendData();
            }
        }

        public void Add(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}
