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
        /// 根据主键获取单个对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="primaryId">主键</param>
        /// <returns>对象实例</returns>
        T GetById<T>(dynamic primaryId, IDbTransaction transaction = null) where T : class;
        /// <summary>
        /// 获取全部对象列表
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>对象实例列表</returns>
        IEnumerable<T> GetAll<T>() where T : class;
        /// <summary>
        /// 根据SQL语句返回查询结果
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sql">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="buffered">使用缓冲区</param>
        /// <returns>对象实例列表</returns>
        IEnumerable<T> Get<T>(string sql, dynamic param = null, bool buffered = true) where T : class;
        /// <summary>
        /// 根据SQL语句返回查询结果
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="buffered">使用缓冲区</param>
        /// <returns>动态实例列表</returns>
        IEnumerable<dynamic> Get(string sql, dynamic param = null, bool buffered = true);
        /// <summary>
        /// 根据SQL语句返回查询结果
        /// </summary>
        /// <typeparam name="TFirst">泛型一</typeparam>
        /// <typeparam name="TSecond">泛型二</typeparam>
        /// <typeparam name="TReturn">泛型三</typeparam>
        /// <param name="sql">查询语句</param>
        /// <param name="map">映射规则</param>
        /// <param name="param">查询参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="buffered">使用缓冲区</param>
        /// <param name="splitOn">字段</param>
        /// <param name="commandTimeout">超时设置</param>
        /// <returns>动态实例列表</returns>
        IEnumerable<TReturn> Get<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null);
        /// <summary>
        /// 根据SQL语句返回多个查询结果
        /// </summary>
        /// <param name="sql">多条SQL语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置</param>
        /// <param name="commandType">命令类型</param>
        /// <returns>多条查询结果</returns>
        SqlMapper.GridReader GetMultiple(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// 查询记录条数
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="predicate">表达式</param>
        /// <param name="buffered">使用缓冲区</param>
        /// <returns>满足表达式的记录条数</returns>
        int Count<T>(IPredicate predicate, bool buffered = false) where T : class;
        /// <summary>
        /// 查询记录列表
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="predicate">表达式</param>
        /// <param name="sort">排序</param>
        /// <param name="buffered">使用缓冲区</param>
        /// <returns>满足表达式的记录列表</returns>
        IEnumerable<T> GetList<T>(IPredicate predicate = null, IList<ISort> sort = null, bool buffered = false) where T : class;
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="allRowsCount">总数量</param>
        /// <param name="predicate">表达式</param>
        /// <param name="sort">排序</param>
        /// <param name="buffered">使用缓冲区</param>
        /// <returns>分页查询结果</returns>
        IEnumerable<T> GetPage<T>(int pageIndex, int pageSize, out long allRowsCount, IPredicate predicate = null, ISort sort = null, bool buffered = true) where T : class;
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
        IEnumerable<T> GetPage<T>(int pageIndex, int pageSize, out long allRowsCount, IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class;
        #endregion

        #region 非查询接口
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="transaction">事务</param>
        /// <returns>受影响行数</returns>
        int Execute(string sql, dynamic param = null, IDbTransaction transaction = null);
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entity">对象实例</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        dynamic Insert<T>(T entity, IDbTransaction transaction = null) where T : class;
        /// <summary>
        /// 更新对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entity">对象实例</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        bool Update<T>(T entity, IDbTransaction transaction = null) where T : class;
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="primaryId">主键</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        bool Delete<T>(dynamic primaryId, IDbTransaction transaction = null) where T : class;
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="predicate">表达式</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        bool Delete<T>(IPredicate predicate, IDbTransaction transaction = null) where T : class;
        #endregion
    }
}
