using BimCheck.IBll;
using BimCheck.IDal;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.Bll
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:30:33
    /// 描述：
    /// </summary>
    public abstract class ServiceBase : IService
    {
        private IDataRepository _dataRepository;
        private Logger _logger;

        /// <summary>
        /// 基础数据操作接口
        /// </summary>
        public IDataRepository DataRepository
        {
            get
            {
                return _dataRepository;
            }
            set
            {
                _dataRepository = value;
            }
        }

        /// <summary>
        /// 日志
        /// </summary>
        public Logger logger
        {
            get
            {
                return _logger;
            }
            set
            {
                _logger = value;
            }
        }
    }
}
