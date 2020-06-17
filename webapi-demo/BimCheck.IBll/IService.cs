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

        //select
        T1 GetById<T1, T2>(dynamic primaryId)
            where T1 : class
            where T2 : class;

        IEnumerable<T1> GetAll<T1, T2>()
            where T1 : class
            where T2 : class;

        IEnumerable<T1> Get<T1, T2>(string sql, dynamic param = null)
            where T1 : class
            where T2 : class;

        IEnumerable<TReturn> Get<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map,
            dynamic param = null);

        IEnumerable<T1> GetPage<T1, T2>(int pageIndex, int pageSize, out long allRowsCount, IPredicate predicate = null, IList<ISort> sort = null)
            where T1 : class
            where T2 : class;
    }
}
