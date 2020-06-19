using BimCheck.IDal;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.IBll
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:29:31
    /// 描述：
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// DAL服务
        /// </summary>
        IDataRepository DataRepository { get; set; }
    }
}
