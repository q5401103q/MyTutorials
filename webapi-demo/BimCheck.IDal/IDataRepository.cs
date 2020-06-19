using Dapper;
using DapperExtensions;
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
    /// 时间：2020/6/15 9:04:09
    /// 描述：
    /// </summary>
    public interface IDataRepository
    {
        /// <summary>
        /// 持有Session接口
        /// </summary>
        ISession Session { get; }

        #region 查询接口
        /// <summary>
        /// 根据id获取单个对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="id">主键</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <returns></returns>
        T Get<T>(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        /// <summary>
        /// 根据查询语句获取数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sql">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="commandType">操作类型包括文本或存储过程等</param>
        /// <returns></returns>
        T GetFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) where T : class;
        /// <summary>
        /// 根据查询语句获取数据
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="commandType">操作类型包括文本或存储过程等</param>
        /// <returns></returns>
        dynamic GetFirstOrDefault(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// 根据查询语句获取对象列表
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sql">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="buffered">使用缓存</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="commandType">操作类型包括文本或存储过程等</param>
        /// <returns></returns>
        IEnumerable<T> GetList<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null) where T : class;
        /// <summary>
        /// 根据表达式获取对象列表
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="predicate">表达式</param>
        /// <param name="sort">排序字段</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="buffered">使用缓冲区</param>
        /// <returns></returns>
        IEnumerable<T> GetList<T>(object predicate = null, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null, bool buffered = false) where T : class;
        /// <summary>
        /// 根据SQL语句获取对象列表
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="buffered">使用缓存</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="commandType">操作类型包括文本或存储过程等</param>
        /// <returns></returns>
        IEnumerable<dynamic> GetList(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// 查询记录条数
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="predicate">表达式</param>
        /// <param name="buffered">使用缓冲区</param>
        /// <returns>满足表达式的记录条数</returns>
        int Count<T>(IPredicate predicate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        /// <summary>
        /// 多排序条件的分页查询
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="allRowsCount">总数量</param>
        /// <param name="predicate">表达式</param>
        /// <param name="sort">排序</param>
        /// <param name="buffered">使用缓冲区</param>
        /// <returns>分页查询结果</returns>
        IEnumerable<T> GetPage<T>(int pageIndex, int pageSize, out long allRowsCount, IPredicate predicate = null, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null, bool buffered = false) where T : class;
        #endregion

        #region 非查询接口
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">语句</param>
        /// <param name="param">参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="commandType">操作类型包括文本或存储过程等</param>
        /// <returns></returns>
        int Execute(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entity">对象实例</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <returns>插入的主键</returns>
        dynamic Insert<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        /// <summary>
        /// 批量插入对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entities">对象实例列表</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        void Insert<T>(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        /// <summary>
        /// 更新对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entity">对象实例</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <returns></returns>
        bool Update<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        /// <summary>
        /// 根据ID删除对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="id">主键</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <returns></returns>
        bool Delete<T>(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        /// <summary>
        /// 根据表达式删除对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="predicate">表达式</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <returns></returns>
        bool Delete<T>(IPredicate predicate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        /// <summary>
        /// 根据实例删除对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entity">对象实例</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置秒（秒）</param>
        /// <returns></returns>
        bool Delete<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        #endregion
    }
}
