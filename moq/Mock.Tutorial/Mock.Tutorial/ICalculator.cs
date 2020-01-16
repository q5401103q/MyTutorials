using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Tutorial
{
    /// <summary>
    /// 计算接口
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// 计算美元到人民币的转换结果
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        int ConvertUSDtoRMB(int unit);
    }
}
