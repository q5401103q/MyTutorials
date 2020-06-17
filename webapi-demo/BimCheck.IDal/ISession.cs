using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.IDal
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:04:48
    /// 描述：
    /// </summary>
    public interface ISession : IDisposable
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        IDbConnection Connection { get; }
        /// <summary>
        /// 事务
        /// </summary>
        IDbTransaction Transaction { get; }
        /// <summary>
        /// 开启事务
        /// </summary>
        /// <param name="isolation">隔离级别，读已提交</param>
        /// <returns></returns>
        IDbTransaction Begin(IsolationLevel isolation = IsolationLevel.ReadCommitted);
        /// <summary>
        /// 提交事务
        /// </summary>
        void Commit();
        /// <summary>
        /// 回滚事务
        /// </summary>
        void Rollback();
    }
}
