using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Prototype.lzl
{
    [Serializable]
    class MyPrototype : AbstractPrototype, IDeepClone, IShallowClone
    {
        public object DeepClone()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, this);
            memoryStream.Position = 0;
            return formatter.Deserialize(memoryStream);
        }

        public object ShallowClone()
        {
            return this.MemberwiseClone();
        }

        public override AbstractPrototype Clone(bool isDeep)
        {
            if (isDeep)
            {
                return DeepClone() as AbstractPrototype;
            }
            else
            {
                return ShallowClone() as AbstractPrototype;
            }
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", Member.Name, Member.Value);
        }
    }
}
