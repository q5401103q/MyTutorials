using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory.lzl
{
    class RealFactory<T> : AbstractFactory<T>
    {
        public override T GetParam()
        {
            T t = Activator.CreateInstance<T>();
            PropertyInfo propertyID = typeof(T).GetProperty("ID");
            PropertyInfo propertyName = typeof(T).GetProperty("Name");
            if(t is RequestParam)
            {
                propertyID.SetValue(t, 1); 
                propertyName.SetValue(t, "Request");                
            }
            else
            {
                propertyID.SetValue(t, 2);
                propertyName.SetValue(t, "Response");     
            }
            return t;
        }
    }
}
