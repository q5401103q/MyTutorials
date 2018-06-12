using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DesignPattern.Template.Implement02
{
    public abstract class DataAccessObject
    {
        protected string connectionString;
        protected DataSet dataSet;

        public virtual void Connect()
        {
            connectionString = "Server=Rj-097;User Id=sa;Password=sa;Database=Northwind";
        }

        public virtual void DisConnect()
        {
            connectionString = string.Empty;
        }

        public abstract void Select();
        public abstract void Display();

        public void Run()
        {
            Connect();
            Select();
            Display();
            DisConnect();
        }
    }
}
