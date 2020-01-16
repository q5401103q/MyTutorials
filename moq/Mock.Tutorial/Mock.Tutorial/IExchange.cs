using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Tutorial
{
    /// <summary>
    /// 汇率接口
    /// </summary>
    public interface IExchange
    {
        /// <summary>
        /// 返回动态的汇率结果
        /// </summary>
        /// <returns></returns>
        int GetActualUSDValue();
    }
}
