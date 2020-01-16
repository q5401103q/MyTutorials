using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Tutorial
{
    /// <summary>
    /// 计算器的实现类
    /// </summary>
    public class Calculator : ICalculator
    {
        /// <summary>
        /// 应当通过DI注入
        /// </summary>
        private IExchange _exchange;

        /// <summary>
        /// 构造方法注入
        /// </summary>
        /// <param name="exchange"></param>
        public Calculator(IExchange exchange)
        {
            this._exchange = exchange;
        }

        /// <summary>
        /// 实现接口
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public int ConvertUSDtoRMB(int unit)
        {
            return unit * this._exchange.GetActualUSDValue();
        }
    }
}
