using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.sequence
{
    public class NumberGenerator
    {
        private static object locker = new object();

        private static int sn = 0;

        public static string Next()
        {
            lock (locker)
            {
                if (sn == 999999999)
                    sn = 0;
                else
                    sn++;

                return $"NUMBER-{DateTime.Now.ToString("yyyyMMddHHmmss")}-{sn.ToString().PadLeft(4, '0')}";
            }
        }

        // 防止创建类的实例
        private NumberGenerator()
        {
        }
    }
}
