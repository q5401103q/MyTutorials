using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DesignPattern.Prototype.Implement01
{
    [Serializable]
    public class ConcteteColorPrototype : ColorPrototype
    {
        private int _red;
        private int _green;
        private int _blue;

        public ConcteteColorPrototype(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        public override ColorPrototype Clone(bool deep)
        {
            if (deep)
                return CreateDeepCopy();
            else
                return CreateShallowCopy();
        }

        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns></returns>
        public ColorPrototype CreateDeepCopy()
        {
            ColorPrototype colorPrototype;
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, this);
            memoryStream.Position = 0;
            colorPrototype = (ColorPrototype)formatter.Deserialize(memoryStream);
            return colorPrototype;
        }

        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <returns></returns>
        public ColorPrototype CreateShallowCopy()
        {
            return (ColorPrototype)this.MemberwiseClone();
        }

        public ConcteteColorPrototype Create(int red, int green, int blue)
        {
            return new ConcteteColorPrototype(red, green, blue);
        }

        public void Display(string colorname)
        {
            Console.Out.WriteLine("{0}'s RGB Values are: {1},{2},{3}", colorname, _red, _green, _blue);
        }
    }
}
